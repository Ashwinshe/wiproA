using SmartMart.Models.Entities;

namespace SmartMart.Services.Interfaces;

// Defines business operations related to Order processing.
// This interface ensures separation of concerns between
// business logic and data access.

public interface IOrderService
{
    // Retrieves all orders from the system.
    // Used by reporting and operational monitoring.
    // <returns>
    // A collection of Order entities.
    // </returns>
    Task<IEnumerable<Order>> GetAllOrdersAsync();


    // Creates a new order in a transactional manner.

    // Business Responsibilities:
    // - Validate stock availability
    // - Deduct inventory
    // - Persist order
    // - Ensure atomic transaction

    // If any step fails, the transaction is rolled back.

    // <"order">
    // The Order entity containing order items and quantities.


    // The created Order entity with generated OrderId.

    Task<Order> CreateOrderAsync(Order order);
}