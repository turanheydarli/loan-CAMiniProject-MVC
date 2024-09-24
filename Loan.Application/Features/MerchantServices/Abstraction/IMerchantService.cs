using Loan.Application.Features.AuthServices.DTOs;
using Loan.Application.Features.MerchantServices.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Features.MerchantServices.Abstraction;

public interface IMerchantService
{
    Task<MerchantDto> CreateMerchantAsync(MerchantCreateDto merchant, string userId, UserRegisterDto userDto = null);
    Task<MerchantDto> GetMerchantByIdAsync(int merchantId);
    Task<IEnumerable<MerchantDto>> GetAllMerchantsAsync();
    Task<MerchantDto> UpdateMerchantAsync(MerchantUpdateDto merchant);
    Task DeleteMerchantAsync(int merchantId);
}