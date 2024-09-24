
using System.Security.Claims;
using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Loan.DataAccess;

public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
{
    public CustomUserClaimsPrincipalFactory(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);

        var userRoles = await UserManager.GetRolesAsync(user);
        
        foreach (var roleName in userRoles)
        {
            identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
        }

        return identity;
    }
}