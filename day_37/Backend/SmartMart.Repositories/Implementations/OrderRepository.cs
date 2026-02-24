using Microsoft.EntityFrameworkCore;
using SmartMart.Models.Entities;
using SmartMart.Repositories.Data;
using SmartMart.Repositories.Interfaces;

namespace SmartMart.Repositories.Implementations;

// Handles Order-related database operations
public class OrderRepository : IOrderRepository
{
    private readonly SmartMartDbContext _context;

    public OrderRepository(SmartMartDbContext context)
    {
        _context = context;
    }

    // Retrieve all orders including their OrderItems
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderItems) // Load related OrderItems
            .ToListAsync();
    }

    // Add a new order to database
    public async Task AddAsync(Order order)
    {
        // Adds order and its related OrderItems
        await _context.Orders.AddAsync(order);

        // Save changes
        await _context.SaveChangesAsync();
    }
}