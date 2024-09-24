using Loan.Application.Features.MerchantServices.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Features.BranchServices.DTOs;

public record BranchDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    
    public string Name { get; set; }
    public int MerchantId { get; set; }
    public int AddressId { get; set; }

    public MerchantDto Merchant { get; set; }
    public Address Address { get; set; }
    public ICollection<Employee> Employees { get; set; }  
    public ICollection<Category> Categories { get; set; }  
}

public record BranchCreateDto
{
    public string Name { get; set; }
    public int MerchantId { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
}
