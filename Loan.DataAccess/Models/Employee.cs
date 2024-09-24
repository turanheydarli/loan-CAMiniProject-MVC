namespace Loan.DataAccess.Models;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }

    public Branch Branch { get; set; }
    public AppUser User { get; set; }
    public ICollection<Loan> Loans { get; set; }
}