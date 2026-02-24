using Microsoft.EntityFrameworkCore;
using SmartMart.Models.Entities;
using SmartMart.Repositories.Data;
using SmartMart.Repositories.Interfaces;

namespace SmartMart.Repositories.Implementations;
// Repository pattern abstracts data access logic from business logic
// Handles all Inventory-related database operations
public class InventoryRepository : IInventoryRepository
{
    private readonly SmartMartDbContext _context;

    public InventoryRepository(SmartMartDbContext context)
    {
        _context = context;
    }

    // Get all inventory records including Product details
    public async Task<IEnumerable<Inventory>> GetAllAsync()
    {
        // Include loads related Product data (navigation property)
        return await _context.Inventories
            .Include(i => i.Product)
            .ToListAsync();
    }

    // Get available stock for a specific product
    public async Task<int> GetAvailableStockAsync(int productId)
    {
        var inventory = await _context.Inventories
            .FirstOrDefaultAsync(i => i.ProductId == productId);

        // If inventory not found, return 0
        return inventory?.QuantityAvailable ?? 0;
    }

    // Update stock quantity
    public async Task UpdateStockAsync(int productId, int quantityChange)
    {
        var inventory = await _context.Inventories
            .FirstOrDefaultAsync(i => i.ProductId == productId);

        // If no inventory record found → throw error
        if (inventory == null)
            throw new Exception("Inventory not found.");

        // Increase or decrease stock
        inventory.QuantityAvailable += quantityChange;

        // Save changes to database
        await _context.SaveChangesAsync();
    }
}