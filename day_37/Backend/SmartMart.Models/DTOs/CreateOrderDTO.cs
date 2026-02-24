namespace SmartMart.Models.DTOs;
// We use CreateOrderDTO to control the input model coming from the client. It prevents exposing internal database
// structure and allows us to validate and process order items properly before converting them into domain entities.
// DTO used when creating a new order from frontend.
// This prevents exposing the full Order entity to the client.
public class CreateOrderDTO
{
    // List of items the customer wants to order
    public List<CreateOrderItemDTO> Items { get; set; } = new();
}

// DTO representing each item inside an order request
public class CreateOrderItemDTO
{
    // ID of the product being ordered
    public int ProductId { get; set; }

    // Quantity requested for that product
    public int Quantity { get; set; }
}