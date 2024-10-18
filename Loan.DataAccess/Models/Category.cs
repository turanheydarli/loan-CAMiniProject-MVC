namespace Loan.DataAccess.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
    public Guid BranchId { get; set; }

    public int Depth { get; set; }

    public Category ParentCategory { get; set; }
    
    public ICollection<Category> SubCategories { get; set; }
    public ICollection<Product> Products { get; set; }
}