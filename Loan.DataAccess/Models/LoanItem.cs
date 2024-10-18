namespace Loan.DataAccess.Models;

public class LoanItem : BaseEntity
{
    public Guid LoanId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Loan Loan { get; set; }
    public Product Product { get; set; }
}