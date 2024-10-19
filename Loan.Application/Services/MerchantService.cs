using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.Mailing;
using Loan.Application.MimeServer;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;
using Microsoft.Extensions.Configuration;

namespace Loan.Application.Services;

public class MerchantService : GenericService<Merchant, MerchantDto>, IMerchantService
{
    private readonly IUserService _userService;
    private readonly IMailService _mailService;
    private readonly IMediaService _mediaService;
    private readonly IConfiguration _configuration;

    public MerchantService(IAsyncRepository<Merchant, AppDbContext> repository, IMapper mapper,
        IUserService userService, IMailService mailService, IMediaService mediaService,
        IConfiguration configuration) : base(repository,
        mapper)
    {
        _userService = userService;
        _mailService = mailService;
        _mediaService = mediaService;
        _configuration = configuration;
    }

    //HACK: Refactor this method. You can use proxies or smth like that to load media files
    //TODO: Convert media model to DTO
    public override async Task<List<MerchantDto>> GetAllAsync()
    {
        var merchants = await base.GetAllAsync();
  
        foreach (var merchant in merchants)
        {
            merchant.BusinessLicense = await _mediaService.GetFileAsync(merchant.BusinessLicenseId);
        }

        return merchants;
    }

    public async Task<MerchantDto> CreateAsync(MerchantDto merchantDto, Guid userId,
        UserRegisterDto userDto = null)
    {
        if (merchantDto == null)
        {
            throw new ArgumentNullException(nameof(merchantDto));
        }

        if (userDto == null)
        {
            throw new ArgumentException("userId or userDto must be provided");
        }

        UserDto user = await _userService.GetUserByIdAsync(userId);

        if (user == null)
        {
            if (userDto == null)
            {
                throw new ArgumentException("user does not exist and user details are not provided");
            }

            user = await _userService.RegisterAsync(userDto);

            if (user == null)
            {
                throw new Exception("failed to create user");
            }
        }

        var merchant = new Merchant
        {
            Name = merchantDto.Name,
            UserId = user.Id,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };

        merchant = await _repository.AddAsync(merchant);

        await _userService.AddUserToRoleAsync(user.Id, "Merchant");

        var createdMerchant = _mapper.Map<MerchantDto>(merchant);

        return createdMerchant;
    }

    public async Task<MerchantDto> ApplyAsync(MerchantDto merchant)
    {
        var existingUser = await _userService.GetUserByEmailAsync(merchant.Email);

        if (existingUser != null)
        {
            throw new ArgumentException("Email is already registered.");
        }

        var registeredUser = await _userService.RegisterAsDraftAsync(new UserDto()
        {
            Email = merchant.Email,
            UserName = merchant.Email,
        });

        await _userService.AddUserToRoleAsync(registeredUser.Id, "Merchant");

        var merchantToCreate = new Merchant
        {
            Name = merchant.Name,
            Email = merchant.Email,
            UserId = registeredUser.Id,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            Status = MerchantStatus.AwaitingApproval,
            CurrentStep = 0,
            RegistrationNotes = merchant.RegistrationNotes,
        };

        var createdMerchant = await _repository.AddAsync(merchantToCreate);

        await _userService.AddUserToRoleAsync(registeredUser.Id, "Merchant");

        if (merchant.BusinessLicense.File is { Length: > 0 })
        {
            var fileId =
                await _mediaService.UploadFileAsync(merchant.BusinessLicense, OwnerType.BusinessLicence,
                    createdMerchant.Id);

            createdMerchant.BusinessLicenseId = fileId;
            await _repository.UpdateAsync(createdMerchant);
        }

        var subject = "Merchant Application Received";
        var message = $"Dear {merchant.Name},\n\n" +
                      "Thank you for applying to become a merchant on our platform. " +
                      "We have received your application and will review it shortly.\n\n" +
                      "Best Regards,\n" +
                      "Loan App";

        await _mailService.SendEmailAsync(merchant.Email, subject, message);

        return _mapper.Map<MerchantDto>(createdMerchant);
    }

    public async Task<bool> ValidateActivationTokenAsync(Guid merchantId, string token)
    {
        var merchant = await _repository.GetAsync(m => m.Id == merchantId);

        if (merchant == null)
        {
            return false;
        }

        if (merchant.ActivationToken != token || merchant.ActivationTokenExpiry < DateTime.UtcNow)
        {
            return false;
        }

        return true;
    }

    public async Task<MerchantDto> CompleteStepOneAsync(Guid merchantId, string password)
    {
        var merchant = await _repository.GetAsync(m => m.Id == merchantId);

        if (merchant == null)
        {
            throw new ArgumentException("Merchant does not exist.");
        }

        // if (merchant.CurrentStep != 0)
        // {
        //     throw new InvalidOperationException("Invalid step.");
        // }

        if (merchant.Status == MerchantStatus.Active)
        {
            throw new InvalidOperationException("Merchant is already active.");
        }

        var user = await _userService.GetUserByIdAsync(merchant.UserId);

        if (user == null)
        {
            throw new ArgumentException("User does not exist.");
        }

        string resetToken = await _userService.GeneratePasswordResetTokenAsync(user);

        await _userService.ResetPasswordAsync(user, resetToken, password);

        await _userService.LoginAsync(new UserLoginDto()
        {
            Username = user.Email,
            IsPersistent = true,
            LockoutOnFailure = false,
            Password = password
        });

        merchant.CurrentStep = 1;
        merchant.ModifiedDate = DateTime.UtcNow;
        await _repository.UpdateAsync(merchant);

        return _mapper.Map<MerchantDto>(merchant);
    }

    public async Task<MerchantDto> CompleteStepTwoAsync(Guid merchantId, MerchantDto merchantDto)
    {
        var merchant = await _repository.GetAsync(m => m.Id == merchantId);

        if (merchant == null)
        {
            throw new ArgumentException("Merchant does not exist.");
        }

        if (merchant.CurrentStep != 1)
        {
            throw new InvalidOperationException("Invalid step.");
        }

        if (merchant.Status == MerchantStatus.Active)
        {
            throw new InvalidOperationException("Merchant is already active.");
        }

        merchant.Name = merchantDto.Name;
        merchant.ModifiedDate = DateTime.UtcNow;

        merchant.CurrentStep = 2;
        merchant.Status = MerchantStatus.Active;
        await _repository.UpdateAsync(merchant);

        return _mapper.Map<MerchantDto>(merchant);
    }

    public async Task<MerchantDto> GetByUserIdAsync(Guid userId)
    {
        var merchant = await _repository.GetAsync(m => m.UserId == userId);

        return _mapper.Map<MerchantDto>(merchant);
    }

    public async Task SetBannerImageAsync(Guid merchantId, MediaDto image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));

        var product = await _repository.GetAsync(p => p.Id == merchantId);

        if (product == null)
            throw new ApplicationException($"Merchant with ID {merchantId} not found.");

        var addedImageId = await _mediaService.UploadFileAsync(image, OwnerType.MerchantBanner, merchantId);

        product.BannerImageId = addedImageId;

        product.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(product);
    }

    public async Task SetProfileImageAsync(Guid merchantId, MediaDto image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));

        var product = await _repository.GetAsync(p => p.Id == merchantId);

        if (product == null)
            throw new ApplicationException($"Merchant with ID {merchantId} not found.");


        var addedImageId = await _mediaService.UploadFileAsync(image, OwnerType.MerchantProfile, merchantId);

        product.ProfileImageId = addedImageId;

        product.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(product);
    }

    public async Task<List<MerchantDto>> GetAllAppliedAsync()
    {
        var merchants = await _repository.GetListAsync(m => m.Status == MerchantStatus.AwaitingApproval);

        return _mapper.Map<List<MerchantDto>>(merchants);
    }

    public async Task<MerchantDto> RejectApplication(Guid merchantId)
    {
        var merchantToUpdate = await _repository.GetAsync(m => m.Id == merchantId);

        if (merchantToUpdate == null)
        {
            throw new ArgumentException("Merchant does not exist.");
        }

        if (merchantToUpdate.Status != MerchantStatus.AwaitingApproval)
        {
            throw new ArgumentException($"Merchant already {merchantToUpdate.Status}.");
        }

        merchantToUpdate.Status = MerchantStatus.Rejected;

        await _repository.UpdateAsync(merchantToUpdate);

        var subject = "Merchant Application Rejection";
        var message = $"Dear {merchantToUpdate.Name},\n\n" +
                      "We are sorry." +
                      "We reviewed you application but your business is not fit our merchant requirements.\n\n" +
                      "Best Regards,\n" +
                      "Loan App";

        await _mailService.SendEmailAsync(merchantToUpdate.Email, subject, message);

        return _mapper.Map<MerchantDto>(merchantToUpdate);
    }

    public async Task<MerchantDto> ApproveApplication(Guid merchantId)
    {
        var merchantToUpdate = await _repository.GetAsync(m => m.Id == merchantId);

        if (merchantToUpdate == null)
        {
            throw new ArgumentException("Merchant does not exist.");
        }

        if (merchantToUpdate.Status != MerchantStatus.AwaitingApproval)
        {
            throw new ArgumentException($"Merchant already {merchantToUpdate.Status}.");
        }

        merchantToUpdate.Status = MerchantStatus.Approved;
        merchantToUpdate.ModifiedDate = DateTime.UtcNow;

        var activationToken = Guid.NewGuid().ToString();

        merchantToUpdate.ActivationToken = activationToken;
        merchantToUpdate.ActivationTokenExpiry = DateTime.UtcNow.AddDays(7);

        await _repository.UpdateAsync(merchantToUpdate);

        var baseUrl = _configuration["AppSettings:BaseUrl"];
        var activationLink = $"{baseUrl}/Merchant/Activate?merchantId={merchantToUpdate.Id}&token={activationToken}";

        var subject = "Activate Your Merchant Account";
        var message = $"Dear {merchantToUpdate.Name},\n\n" +
                      "Congratulations! Your merchant application has been approved.\n\n" +
                      "Please activate your account by clicking the link below:\n" +
                      $"{activationLink}\n\n" +
                      $"This link will expire on {merchantToUpdate.ActivationTokenExpiry.ToLocalTime():MMMM dd, yyyy}.\n\n" +
                      "Best Regards,\n" +
                      "Loan App Team";

        await _mailService.SendEmailAsync(merchantToUpdate.Email, subject, message);

        return _mapper.Map<MerchantDto>(merchantToUpdate);
    }
}