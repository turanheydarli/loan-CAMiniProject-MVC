namespace Loan.DataAccess.Models;

public class Loan : BaseEntity
{
    public string Title { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalAmount { get; set; }
    public string Terms { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }

    public Customer Customer { get; set; }
    public Employee Employee { get; set; }
    public ICollection<LoanItem> LoanItems { get; set; }  
    public ICollection<Payment> Payments { get; set; } 
}