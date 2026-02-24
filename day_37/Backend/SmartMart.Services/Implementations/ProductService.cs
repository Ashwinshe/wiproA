using SmartMart.Models.Entities;
using SmartMart.Repositories.Interfaces;
using SmartMart.Services.Interfaces;

namespace SmartMart.Services.Implementations;

// Service implementation for Product-related business logic
public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    
     // Get all products
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _repository.GetAllAsync();
    }
     
    // Get product by ID
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
    
    // Add a new product
    public async Task AddProductAsync(Product product)
    {
        await _repository.AddAsync(product);
    }
}