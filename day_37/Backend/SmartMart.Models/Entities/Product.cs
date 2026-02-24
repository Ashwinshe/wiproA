using SmartMart.Models.Entities;

namespace SmartMart.Models.Entities;

public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int SupplierId { get; set; }

    public Supplier? Supplier { get; set; }

    public Inventory? Inventory { get; set; }
}