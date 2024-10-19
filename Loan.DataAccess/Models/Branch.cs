namespace Loan.DataAccess.Models;

public class Branch : BaseEntity
{
    public string Name { get; set; }
    public Guid MerchantId { get; set; }
    public Guid AddressId { get; set; }

    public virtual Merchant Merchant { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }  
}