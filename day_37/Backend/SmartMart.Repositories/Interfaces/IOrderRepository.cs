using SmartMart.Models.Entities;

namespace SmartMart.Repositories.Interfaces;

// Interface for Order data access
// Defines operations that can be performed on the Orders table
public interface IOrderRepository
{
    // Get all orders with their items
    Task<IEnumerable<Order>> GetAllAsync();

    // Add a new order
    Task AddAsync(Order order);
}