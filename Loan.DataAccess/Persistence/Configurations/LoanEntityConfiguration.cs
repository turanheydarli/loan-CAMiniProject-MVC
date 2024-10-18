using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loan.DataAccess.Persistence.Configurations;

public class LoanEntityConfiguration : IEntityTypeConfiguration<Loan.DataAccess.Models.Loan>
{
    public void Configure(EntityTypeBuilder<Models.Loan> builder)
    {
        builder.HasOne(e => e.Employee).WithMany().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
    }
}