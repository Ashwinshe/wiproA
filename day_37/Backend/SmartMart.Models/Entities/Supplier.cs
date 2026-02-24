namespace SmartMart.Models.Entities;

public class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = string.Empty;

    public string? ContactEmail { get; set; }

    public List<Product> Products { get; set; } = new();
}