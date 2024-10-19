using Loan.DataAccess.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Loan.DataAccess.Models;

[EntityTypeConfiguration(typeof(EmployeeEntityConfiguration))]
public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public Guid BranchId { get; set; }
    public Guid UserId { get; set; }

    public virtual Branch Branch { get; set; }
    public virtual AppUser User { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}