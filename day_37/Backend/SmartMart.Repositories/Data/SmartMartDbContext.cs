using Microsoft.EntityFrameworkCore;
using SmartMart.Models.Entities;

// connects your application to the database using Entity Framework Core.
// translates LINQ queries into SQL

namespace SmartMart.Repositories.Data;

public class SmartMartDbContext : DbContext
{
    public SmartMartDbContext(DbContextOptions<SmartMartDbContext> options)
        : base(options)
    {
    }

    // A database table

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use exact table name
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<OrderItem>().ToTable("OrderItems");


        modelBuilder.Entity<Inventory>().ToTable("Inventory");

        base.OnModelCreating(modelBuilder);
    }
}