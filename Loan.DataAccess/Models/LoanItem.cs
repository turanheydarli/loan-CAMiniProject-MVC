namespace Loan.DataAccess.Models;

public class LoanItem : BaseEntity
{
    public Guid LoanId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public virtual Loan Loan { get; set; }
    public virtual Product Product { get; set; }
}