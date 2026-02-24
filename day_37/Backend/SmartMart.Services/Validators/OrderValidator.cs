using SmartMart.Common.Enums;
using SmartMart.Common.Exceptions;

namespace SmartMart.Services.Validators;

// To separate validation logic from service logic. 
//This improves readability, reusability, and maintainability while keeping business rules centralized.

public static class OrderValidator // Responsible for validating business rules related to Orders
{
    public static void ValidateStock(int availableStock, int requestedQuantity)
    {
        if (availableStock < requestedQuantity)
            throw new InsufficientStockException("Not enough stock available.");
    }

    public static void ValidateStatusTransition(OrderStatus current, OrderStatus next)
    {
        if (current == OrderStatus.Cancelled)
            throw new InvalidOrderStateException("Cancelled orders cannot be updated.");
    }
}