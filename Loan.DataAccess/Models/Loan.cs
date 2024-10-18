using Loan.DataAccess.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Loan.DataAccess.Models;

[EntityTypeConfiguration(typeof(LoanEntityConfiguration))]
public class Loan : BaseEntity
{
    public string Title { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalAmount { get; set; }
    public string Terms { get; set; }
    public Guid CustomerId { get; set; }
    public Guid EmployeeId { get; set; }

    public Customer Customer { get; set; }
    public Employee Employee { get; set; }
    public ICollection<LoanItem> LoanItems { get; set; }
    public ICollection<Payment> Payments { get; set; }
}