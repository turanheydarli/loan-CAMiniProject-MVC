using Loan.DataAccess.Models;

namespace Loan.Application.DTOs;

public record BranchDto : BaseDto
{
    public string Name { get; set; }
    public int MerchantId { get; set; }
    public int AddressId { get; set; }

    public MerchantDto Merchant { get; set; }
    public Address Address { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Category> Categories { get; set; }
}