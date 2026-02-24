using Microsoft.EntityFrameworkCore;
using SmartMart.Models.Entities;
using SmartMart.Repositories.Interfaces;
using SmartMart.Repositories.Data;
using SmartMart.Services.Interfaces;
using SmartMart.Services.Validators;

namespace SmartMart.Services.Implementations;

// Service for Order-related business logic
public class OrderService : IOrderService
{
    // Repositories for data access
    // need transaction control
    private readonly IOrderRepository _orderRepository;
    private readonly IInventoryRepository _inventoryRepository;
    
    // DbContext to manage database transactions
    private readonly SmartMartDbContext _dbContext;

    // Constructor injection (Dependency Injection)
    public OrderService(
        IOrderRepository orderRepository,
        IInventoryRepository inventoryRepository,
        SmartMartDbContext dbContext)
    {
        _orderRepository = orderRepository;
        _inventoryRepository = inventoryRepository;
        _dbContext = dbContext;
    }
    
    // Get all orders along with their items
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        // Delegates to repository to fetch all orders
        return await _orderRepository.GetAllAsync();
    }
    
    // Create a new order with transactional stock deduction
    public async Task<Order> CreateOrderAsync(Order order)
    {
        // Begin a database transaction to ensure atomic operation 
        // Atomic operation
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            // Loop through each item in the order
            foreach (var item in order.OrderItems)
            {
                // Check available stock for the product
                var stock = await _inventoryRepository.GetAvailableStockAsync(item.ProductId);

                // Validate that requested quantity does not exceed available stock
                OrderValidator.ValidateStock(stock, item.Quantity);

                // Deduct the requested quantity from inventory
                await _inventoryRepository.UpdateStockAsync(item.ProductId, -item.Quantity);
            }

            // Save the order to the database after all stock checks
            await _orderRepository.AddAsync(order);

            // Commit the transaction if everything succeeds
            await transaction.CommitAsync();

            // Return the successfully created order
            return order;
        }
        catch (DbUpdateConcurrencyException)
        {
            // Handle concurrency conflicts (e.g., two users ordering same stock simultaneously)
            await transaction.RollbackAsync();
            throw new Exception("Inventory conflict occurred. Please retry.");
        }
        catch
        {
            // Rollback transaction for any other errors
            await transaction.RollbackAsync();
            throw; // Re-throw the exception to be handled by middleware
        }
    }
}