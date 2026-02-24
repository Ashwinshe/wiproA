using Microsoft.AspNetCore.Mvc;
using SmartMart.Services.Interfaces;

namespace SmartMart.API.Controllers;

// Marks this class as a Web API controller
[ApiController]

// Route pattern: api/inventory
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    // Service dependency (business logic layer)
    private readonly IInventoryService _inventoryService;

    // Constructor Injection
    // ASP.NET Core automatically injects InventoryService
    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    // GET: api/inventory
    // Returns all inventory records
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Call service layer to get data
        var inventory = await _inventoryService.GetAllInventoryAsync();

        // Return HTTP 200 OK with inventory data
        return Ok(inventory);
    }

    // PUT: api/inventory/update-stock?productId=1&quantity=5
    // Updates stock quantity for a product
    [HttpPut("update-stock")]
    public async Task<IActionResult> UpdateStock(int productId, int quantity)
    {
        // Call service layer to update stock
        await _inventoryService.UpdateStockAsync(productId, quantity);

        // Return success response
        return Ok("Stock updated successfully");
    }
}