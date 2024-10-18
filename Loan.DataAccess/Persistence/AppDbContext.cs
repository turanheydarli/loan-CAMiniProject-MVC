using System.Reflection;
using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Loan.DataAccess.Persistence;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Loan.DataAccess.Models.Loan> Loans { get; set; }
    public DbSet<LoanItem> LoanItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<CarouselItem> CarouselItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Media> Medias { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppDbContext)) ??
                                                Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}

//  dotnet ef migrations add MerchandFileFieldUpdated --project ./Loan.DataAccess --startup-project ./Loan.WebMVC/  
