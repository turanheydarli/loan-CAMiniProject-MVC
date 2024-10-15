using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace Loan.Application.DTOs;

public record MerchantDto : BaseDto
{
    public string Name { get; set; }
    public string UserId { get; set; }
    public IFormFile BusinessLicense { get; set; }
    public string RegistrationNotes { get; set; }
    public MerchantStatus Status { get; set; }
    public string Email { get; set; }

    public int CurrentStep { get; set; }
    public string BusinessLicensePath { get; set; }

    public AppUser User { get; set; }
    public ICollection<Branch> Branches { get; set; }
}