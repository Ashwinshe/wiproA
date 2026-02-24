using SmartMart.Models.Entities;
using SmartMart.Repositories.Interfaces;
using SmartMart.Services.Interfaces;

namespace SmartMart.Services.Implementations;

// Service for Inventory-related operations
public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }
    
    // Get all inventory records
    public async Task<IEnumerable<Inventory>> GetAllInventoryAsync()
    {
        return await _repository.GetAllAsync();
    }
    
     // Update stock for a product
    public async Task UpdateStockAsync(int productId, int quantity)
    {
        await _repository.UpdateStockAsync(productId, quantity);
    }
    
    // Get available stock for a product
    public async Task<int> GetAvailableStockAsync(int productId)
    {
        return await _repository.GetAvailableStockAsync(productId);
    }
}