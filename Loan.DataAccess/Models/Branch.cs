namespace Loan.DataAccess.Models;

public class Branch : BaseEntity
{
    public string Name { get; set; }
    public Guid MerchantId { get; set; }
    public Guid AddressId { get; set; }

    public Merchant Merchant { get; set; }
    public Address Address { get; set; }
    public ICollection<Employee> Employees { get; set; }  
}