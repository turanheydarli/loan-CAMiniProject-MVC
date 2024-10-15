using Loan.DataAccess.Factories;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loan.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<AppUser, AppRole>()
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<AppDbContext>()   
            .AddDefaultTokenProviders();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.AccessDeniedPath = "/auth/accessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
            });


        services.AddAuthorization();
        
        services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomUserClaimsPrincipalFactory>();

        services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
        services.AddScoped(typeof(IAsyncRepository<,>), typeof(EfRepository<,>));

        return services;
    }
}