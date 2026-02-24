namespace SmartMart.Models.DTOs;

// DTO returned to frontend after order is created or fetched
public class OrderResponseDTO
{
    // Unique identifier of the order
    public int OrderId { get; set; }

    // Date when order was created
    public DateTime OrderDate { get; set; }

    // Current order status (Pending, Confirmed, etc.)
    public string Status { get; set; } = string.Empty;

    // List of items included in this order
    public List<OrderItemResponseDTO> Items { get; set; } = new();
}

// DTO representing each item in the response
public class OrderItemResponseDTO
{
    // Product ID of ordered item
    public int ProductId { get; set; }

    // Quantity ordered
    public int Quantity { get; set; }
}