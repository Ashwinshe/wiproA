using SmartMart.Models.Entities;

namespace SmartMart.Repositories.Interfaces;

// Interface for Product data access
// Defines operations that can be performed on the Products table
public interface IProductRepository
{
    // Get all products
    Task<IEnumerable<Product>> GetAllAsync();

    // Get a single product by ID
    Task<Product?> GetByIdAsync(int id);

    // Add a new product
    Task AddAsync(Product product);
}