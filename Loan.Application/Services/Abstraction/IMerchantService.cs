using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction;

public interface IMerchantService : IGenericService<Merchant, MerchantDto>
{
    Task<MerchantDto> CreateAsync(MerchantDto merchant, string userId, UserRegisterDto userDto = null);
    Task<MerchantDto> ApplyAsync(MerchantDto merchant, UserDto user);
    Task<List<MerchantDto>> GetAllAppliedAsync();
    Task<MerchantDto> RejectApplication(int merchantId);
    Task<MerchantDto> ApproveApplication(int merchantId);
    
    Task<bool> ValidateActivationTokenAsync(int merchantId, string token);
    Task<MerchantDto> CompleteStepOneAsync(int merchantId, string password);
    Task<MerchantDto> CompleteStepTwoAsync(int merchantId, MerchantDto merchantDto);
}