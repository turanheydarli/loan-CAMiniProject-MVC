using Loan.Application.Extensions;
using Loan.DataAccess.Extensions;
using Loan.WebMVC.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews(op => { op.Filters.Add<GlobalExceptionFilter>(); });
builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddApplicationServices();



var app = builder.Build();

// Configure the HTTP request pipeline.                                   
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

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