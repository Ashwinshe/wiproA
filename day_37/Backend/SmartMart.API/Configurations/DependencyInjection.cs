using SmartMart.Services.Interfaces;
using SmartMart.Services.Implementations;
using SmartMart.Repositories.Interfaces;
using SmartMart.Repositories.Implementations;

namespace SmartMart.API.Configurations;

/// Central place for registering application dependencies.
/// This class follows the Dependency Injection (DI) pattern
/// and keeps Program.cs clean.
public static class DependencyInjection
{

    // Registers all Services and Repositories into the
    // ASP.NET Core Dependency Injection container.
 
    // This allows controllers and other classes to receive
    // dependencies through constructor injection.

    // <param name="services">IServiceCollection provided by ASP.NET Core</param>
    // <returns>Updated IServiceCollection</returns>
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
 
        // Registers business logic services.
        // AddScoped means:
        // One instance is created per HTTP request.

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IOrderService, OrderService>();


        // Registers data access layer classes.
        // These communicate with the database via EF Core.

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();


        // Return the updated service collection
        return services;
    }
}