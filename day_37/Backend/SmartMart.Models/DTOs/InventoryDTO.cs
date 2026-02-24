namespace SmartMart.Models.DTOs;

// DTO used to return inventory details to frontend
public class InventoryDTO
{
    // Product ID
    public int ProductId { get; set; }

    // Name of the product
    public string ProductName { get; set; } = string.Empty;

    // Current available stock quantity
    public int QuantityAvailable { get; set; }
}