using Microsoft.AspNetCore.Mvc;
using SmartMart.Models.DTOs;
using SmartMart.Models.Entities;
using SmartMart.Services.Interfaces;

namespace SmartMart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    // Inject OrderService using Dependency Injection
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // POST: api/orders
    // Creates a new order
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDTO dto)
    {
        // Convert DTO into Entity
        // DTO is received from frontend
        var order = new Order
        {
            OrderItems = dto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        // Call service layer (this handles stock validation + saving)
        var createdOrder = await _orderService.CreateOrderAsync(order);

        // Convert Entity back into Response DTO
        // We do NOT return entity directly (best practice)
        var response = new OrderResponseDTO
        {
            OrderId = createdOrder.OrderId,
            OrderDate = createdOrder.OrderDate,
            Status = createdOrder.Status.ToString(),

            Items = createdOrder.OrderItems.Select(i => new OrderItemResponseDTO
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        // Return HTTP 200 OK with response DTO
        return Ok(response);
    }
}