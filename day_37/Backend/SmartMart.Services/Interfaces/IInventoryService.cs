using SmartMart.Models.Entities;

namespace SmartMart.Services.Interfaces;

// Defines business operations related to inventory management.
// Responsible for stock tracking and updates.

public interface IInventoryService
{
    // <summary>
    // Retrieves all inventory records.
    // Used for warehouse monitoring and reporting.

    Task<IEnumerable<Inventory>> GetAllInventoryAsync();


    // Updates stock quantity for a specific product.
    // Quantity can be positive (restock) or negative (deduction).

    Task UpdateStockAsync(int productId, int quantity);

   
    // Returns available stock quantity for a product.
    // Used during order validation.

    Task<int> GetAvailableStockAsync(int productId);
}