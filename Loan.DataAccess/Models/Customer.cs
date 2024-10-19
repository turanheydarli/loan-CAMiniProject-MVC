using Loan.DataAccess.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Loan.DataAccess.Models;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Occupation { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public Guid ProfileImageId { get; set; }
    public Guid UserId { get; set; }
    public virtual AppUser User { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}