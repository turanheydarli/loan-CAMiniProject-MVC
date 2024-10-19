using Loan.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loan.DataAccess.Persistence.Configurations;

public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasOne(a => a.Branch)
            .WithOne(b => b.Address)
            .HasForeignKey<Address>(a => a.BranchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}