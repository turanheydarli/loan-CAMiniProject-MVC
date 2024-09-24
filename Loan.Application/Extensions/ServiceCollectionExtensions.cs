using System.Reflection;
using Loan.Application.Features.AuthServices;
using Loan.Application.Features.AuthServices.Abstraction;
using Loan.Application.Features.BranchServices;
using Loan.Application.Features.BranchServices.Abstraction;
using Loan.Application.Features.MerchantServices;
using Loan.Application.Features.MerchantServices.Abstraction;
using Loan.Application.MappingProfiles;
using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Loan.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMerchantService, MerchantService>();
        services.AddScoped<IBranchService, BranchService>();
        
        services.AddAutoMapper(Assembly.GetAssembly(typeof(CustomProfile)));

        return services;
    }
}