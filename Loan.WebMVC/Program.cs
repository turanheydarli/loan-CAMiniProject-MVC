using System.Configuration;
using FluentValidation.AspNetCore;
using Loan.Application.Extensions;
using Loan.Application.Validators;
using Loan.DataAccess.Extensions;
using Loan.WebMVC.Extensions;
using Loan.WebMVC.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(o =>
{
    // o.Filters.Add<GlobalExceptionFilter>();
    
}).AddMvcSettings();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddScoped<GlobalExceptionFilter>();

// builder.Logging.AddApplicationLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.                                   
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseNToastNotify();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();