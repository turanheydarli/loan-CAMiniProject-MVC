using Loan.DataAccess.Models;

namespace Loan.Application.DTOs;

public record BranchDto : BaseDto
{
    public string Name { get; set; }
    public Guid MerchantId { get; set; }
    public Guid AddressId { get; set; }

    public MerchantDto Merchant { get; set; }
    public AddressDto Address { get; set; }
    public ICollection<EmployeeDto> Employees { get; set; }
    public ICollection<CategoryDto> Categories { get; set; }
}