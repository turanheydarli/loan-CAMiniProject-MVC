namespace Loan.DataAccess.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }


    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public Guid ThumbnailId { get; set; }

    public virtual ICollection<LoanItem> LoanItems { get; set; }
}