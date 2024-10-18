namespace Loan.DataAccess.Models;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public string PaymentType { get; set; }
    public Guid LoanId { get; set; }

    public Loan Loan { get; set; }
}