using System.ComponentModel.DataAnnotations;
//We used optimistic concurrency control to prevent race conditions during stock updates.
// The RowVersion column ensures that simultaneous updates do not override each other, maintaining data integrity in high-concurrency scenarios like order processing.
namespace SmartMart.Models.Entities;

public class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int QuantityAvailable { get; set; }

    public Product? Product { get; set; }

    [Timestamp] // concurrency
    public byte[]? RowVersion { get; set; }
}