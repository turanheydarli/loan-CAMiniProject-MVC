using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Loan.DataAccess.Persistence.Configurations;

public static class IdentitySeedData
{
    public static readonly Guid AdminRoleId = Guid.NewGuid();

    public static readonly Guid AdminUserId = Guid.NewGuid();

    public static object[] GetRoles()
    {
        return new AppRole[]
        {
            new AppRole
            {
                Id = AdminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
        };
    }

    public static AppUser[] GetUsers()
    {
        var passwordHasher = new PasswordHasher<AppUser>();

        var adminUser = new AppUser
        {
            Id = AdminUserId,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "AdminPassword123!");


        return new AppUser[] { adminUser };
    }

    public static IdentityUserRole<Guid>[] GetUserRoles()
    {
        return new IdentityUserRole<Guid>[]
        {
            new IdentityUserRole<Guid>
            {
                UserId = AdminUserId,
                RoleId = AdminRoleId
            }
        };
    }
}