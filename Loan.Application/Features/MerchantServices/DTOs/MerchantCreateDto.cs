using Loan.DataAccess.Models;

namespace Loan.Application.Features.MerchantServices.DTOs;

public record MerchantDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public string Name { get; set; }
    public string UserId { get; set; }

    public AppUser User { get; set; }
    public ICollection<Branch> Branches { get; set; }
}

public record MerchantCreateDto
{
    public string Name { get; set; }
    public int? UserId { get; set; }
    public AppUser User { get; set; }
}

public record MerchantUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}