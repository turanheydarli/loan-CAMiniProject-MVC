namespace Loan.DataAccess.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }

    public Category Category { get; set; }
    public ICollection<LoanItem> LoanItems { get; set; }  
}