using Loan.Application.AuthServices;
using Loan.Application.AuthServices.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Loan.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}