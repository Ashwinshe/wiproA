namespace SmartMart.Models.Entities;

using SmartMart.Common.Enums;

// Represents Order table
public class Order
{
    // Primary Key
    public int OrderId { get; set; }

    // Date and time when order was created
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    // Order status (Enum instead of string)
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    // Navigation property
    // One Order can contain multiple OrderItems
    public List<OrderItem> OrderItems { get; set; } = new();
}