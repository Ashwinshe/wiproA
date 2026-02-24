namespace SmartMart.Models.Entities;

// Represents OrderItem table
// Each record represents one product inside an order
public class OrderItem
{
    // Primary Key
    public int OrderItemId { get; set; }

    // Foreign Key referencing Product
    public int ProductId { get; set; }

    // Quantity ordered
    public int Quantity { get; set; }

    // Foreign Key referencing Order
    public int OrderId { get; set; }

    // Navigation property to Product
    public Product? Product { get; set; }

    // Navigation property to Order
    public Order? Order { get; set; }
}