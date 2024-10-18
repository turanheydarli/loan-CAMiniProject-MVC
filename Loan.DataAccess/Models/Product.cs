namespace Loan.DataAccess.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }


    public Guid CategoryId { get; set; }

    public Category Category { get; set; }

    public Media Thumbnail { get; set; }

    public ICollection<Media> Images { get; set; }

    public ICollection<LoanItem> LoanItems { get; set; }
}