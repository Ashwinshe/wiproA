using SmartMart.Models.Entities;

namespace SmartMart.Services.Interfaces;

// Defines product-related business operations.
// Ensures separation between controller and repository.

public interface IProductService
{

    // Retrieves all products.
    // Used for product listing.
   
    Task<IEnumerable<Product>> GetAllProductsAsync();

   
    // Retrieves a product by its unique identifier.

    Task<Product?> GetByIdAsync(int id);

 
    // Adds a new product into the system.
    // Business validations (e.g., duplicates) can be applied here.
  
    Task AddProductAsync(Product product);
}