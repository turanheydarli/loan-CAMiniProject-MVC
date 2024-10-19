using Loan.DataAccess.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Loan.DataAccess.Models;

[EntityTypeConfiguration(typeof(CategoryConfiguration))]
public class Category : BaseEntity
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
    public Guid BranchId { get; set; }

    public int Depth { get; set; }

    public virtual Category ParentCategory { get; set; }
    public virtual Guid ThumbnailId { get; set; }

    public virtual ICollection<Category> SubCategories { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}