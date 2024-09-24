using System.Data.SqlTypes;
using AutoMapper;
using Loan.Application.Features.AuthServices.Abstraction;
using Loan.Application.Features.AuthServices.DTOs;
using Loan.Application.Features.MerchantServices.Abstraction;
using Loan.Application.Features.MerchantServices.DTOs;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Features.MerchantServices;

public class MerchantService : IMerchantService
{
    private readonly IAsyncRepository<Merchant, AppDbContext> _merchantRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public MerchantService(IAsyncRepository<Merchant, AppDbContext> merchantRepository, IUserService userService,
        IMapper mapper)
    {
        _merchantRepository = merchantRepository;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<MerchantDto> CreateMerchantAsync(MerchantCreateDto merchantDto, string userId,
        UserRegisterDto userDto = null)
    {
        if (merchantDto == null)
        {
            throw new ArgumentNullException(nameof(merchantDto));
        }

        if (string.IsNullOrWhiteSpace(userId) && userDto == null)
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

        merchant = await _merchantRepository.AddAsync(merchant);

        await _userService.AddUserToRoleAsync(user.Id, "Merchant");

        var createdMerchant = _mapper.Map<MerchantDto>(merchant);

        return createdMerchant;
    }

    public async Task<MerchantDto> GetMerchantByIdAsync(int merchantId)
    {
        Merchant merchant = await _merchantRepository.GetAsync(m => m.Id == merchantId);

        if (merchant == null)
        {
            return null;
        }

        var merchantDto = _mapper.Map<MerchantDto>(merchant);

        return merchantDto;
    }

    public async Task<IEnumerable<MerchantDto>> GetAllMerchantsAsync()
    {
        var allMerchants = await _merchantRepository.GetListAsync();

        IEnumerable<MerchantDto> merchants = _mapper.Map<IEnumerable<MerchantDto>>(allMerchants);

        return merchants;
    }

    public async Task<MerchantDto> UpdateMerchantAsync(MerchantUpdateDto merchant)
    {
        var merchantToUpdate = await _merchantRepository.GetAsync(m => m.Id == merchant.Id);

        if (merchantToUpdate == null)
        {
            throw new ApplicationException("merchant does not exist");
        }

        merchantToUpdate.Name = merchant.Name;
        merchantToUpdate.ModifiedDate = DateTime.UtcNow;

        return _mapper.Map<MerchantDto>(merchantToUpdate);
    }

    public async Task DeleteMerchantAsync(int merchantId)
    {
        var merchantToDelete = await _merchantRepository.GetAsync(m => m.Id == merchantId);

        if (merchantToDelete == null)
        {
            throw new ApplicationException("merchant does not exist");
        }

        await _merchantRepository.DeleteAsync(merchantToDelete);
    }
}