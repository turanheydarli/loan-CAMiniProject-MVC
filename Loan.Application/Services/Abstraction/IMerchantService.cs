using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction;

public interface IMerchantService : IGenericService<Merchant, MerchantDto>
{
    Task<MerchantDto> CreateAsync(MerchantDto merchant, Guid userId, UserRegisterDto userDto = null);
    Task<MerchantDto> ApplyAsync(MerchantDto merchant);
    Task<List<MerchantDto>> GetAllAppliedAsync();
    Task<MerchantDto> RejectApplication(Guid merchantId);
    Task<MerchantDto> ApproveApplication(Guid merchantId);

    Task<bool> ValidateActivationTokenAsync(Guid merchantId, string token);
    Task<MerchantDto> CompleteStepOneAsync(Guid merchantId, string password);
    Task<MerchantDto> CompleteStepTwoAsync(Guid merchantId, MerchantDto merchantDto);
    Task<MerchantDto> GetByUserIdAsync(Guid userId);

    Task SetBannerImageAsync(Guid merchantId, MediaDto image);
    Task SetProfileImageAsync(Guid merchantId, MediaDto image);
}