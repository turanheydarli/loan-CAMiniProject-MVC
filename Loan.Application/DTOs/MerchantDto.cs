using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace Loan.Application.DTOs;

public record MerchantDto : BaseDto
{
    public string Name { get; set; }
    public Guid UserId { get; set; }
    public string RegistrationNotes { get; set; }
    public MerchantStatus Status { get; set; }
    public string Email { get; set; }

    public int CurrentStep { get; set; }
    public Guid BusinessLicenseId { get; set; }

    public AppUser User { get; set; }
    public ICollection<Branch> Branches { get; set; }

    //TODO: Convert it to media DTO
    public MediaDto BusinessLicense { get; set; }
    
    public Guid ProfileImageId { get; set; }
    public MediaDto ProfileImage { get; set; }
    public MediaDto BannerImage { get; set; }
}