using Baxici.DataAccess.Models;
using Baxici.DataAccess.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Baxici.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        void ConfigureDatabaseOptions(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        
        void ConfigureIdentityOptions(IdentityOptions options)
        {
        }
        
        services.AddDbContext<AppDbContext>(ConfigureDatabaseOptions);

        services.AddIdentityCore<AppUser>(ConfigureIdentityOptions)
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();
        
        
        return services;
    }
}