using Microsoft.EntityFrameworkCore;
using SmartMart.Models.Entities;
using SmartMart.Repositories.Data;
using SmartMart.Repositories.Interfaces;

namespace SmartMart.Repositories.Implementations;

// Handles all Product-related database operations
public class ProductRepository : IProductRepository
{
    // EF Core DbContext
    private readonly SmartMartDbContext _context;

    // Constructor injection of DbContext
    public ProductRepository(SmartMartDbContext context)
    {
        _context = context;
    }

    // Retrieves all products from database
    public async Task<IEnumerable<Product>> GetAllAsync()
{
    return await _context.Products
        .Include(p => p.Inventory)   
        .ToListAsync();
}

    // Retrieves a product by its primary key
    public async Task<Product?> GetByIdAsync(int id)
    {
        // FindAsync searches by primary key
        return await _context.Products.FindAsync(id);
    }

    // Adds a new product to the database
    public async Task AddAsync(Product product)
    {
        // Adds entity to EF tracking
        await _context.Products.AddAsync(product);

        // Saves changes to database
        await _context.SaveChangesAsync();
    }
}