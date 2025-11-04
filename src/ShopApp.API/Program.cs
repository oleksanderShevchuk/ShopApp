using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShopApp.API.Middleware;
using ShopApp.Application.Interfaces;
using ShopApp.Application.Services;
using ShopApp.Infrastructure.Persistence;
using ShopApp.Infrastructure.Repositories;
using ShopApp.Infrastructure.UnitOfWork;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelBooking API", Version = "v1" });
        });

        // DbContext
        builder.Services.AddDbContext<ShopDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Infrastructure registrations
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Application services
        builder.Services.AddScoped<IShopService, ShopService>();

        // Middleware logging
        builder.Services.AddLogging();

        // Build
        var app = builder.Build();

        // Middleware pipeline
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnixCarService API v1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}