using System.Reflection;
using Loan.Application.DTOs;
using Loan.Application.Mailing;
using Loan.Application.MappingProfiles;
using Loan.Application.Services;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Loan.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddTransient<IMailService, MailService>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMerchantService, MerchantService>();
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICarouselService, CarouselService>();
        services.AddScoped<IEmployeeService, EmployeeService>();

        services.AddAutoMapper(Assembly.GetAssembly(typeof(CustomProfile)));


        return services;
    }

    public static void AddApplicationLogger(this ILoggingBuilder loggingBuilder)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();

        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(logger);
    }
}