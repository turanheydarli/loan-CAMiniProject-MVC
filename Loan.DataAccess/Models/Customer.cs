namespace Loan.DataAccess.Models;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Occupation { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }

    public AppUser User { get; set; }
    public ICollection<Loan> Loans { get; set; } 
}