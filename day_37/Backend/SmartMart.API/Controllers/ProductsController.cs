using Microsoft.AspNetCore.Mvc; // all classes and attributes
using SmartMart.Services.Interfaces;
using SmartMart.Models.Entities;

namespace SmartMart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    // Constructor Injection
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products
    // Returns all products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Call business logic layer
        var products = await _productService.GetAllProductsAsync();

        // Return HTTP 200 OK with product list
        return Ok(products);
    }

    // POST: api/products
    // Creates a new product
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        // Send product to service layer for saving
        await _productService.AddProductAsync(product);

        // Return success message
        return Ok("Product created successfully");
    }
}