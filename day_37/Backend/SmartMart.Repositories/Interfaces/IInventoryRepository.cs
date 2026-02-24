using SmartMart.Models.Entities;

namespace SmartMart.Repositories.Interfaces;

// Interface for Inventory data access
// Defines operations that can be performed on the Inventory table
public interface IInventoryRepository
{
    // Get all inventory records
    Task<IEnumerable<Inventory>> GetAllAsync();

    // Get available stock for a specific product
    Task<int> GetAvailableStockAsync(int productId);

    // Update stock quantity for a product (increase or decrease)
    Task UpdateStockAsync(int productId, int quantityChange);
}