using System.Text.Json; // Used to convert C# object into JSON format
using SmartMart.Common.Exceptions; // Import custom exceptions

namespace SmartMart.API.Middleware;

// Custom middleware for handling all unhandled exceptions globally
public class ExceptionMiddleware
{
    // Represents the next middleware in the ASP.NET Core request pipeline
    private readonly RequestDelegate _next;

    // Constructor - ASP.NET Core injects the next middleware automatically
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // This method is executed for every HTTP request
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Pass the request to the next middleware or controller
            await _next(context);
        }
        catch (Exception ex)
        {
            // If any exception occurs anywhere in the application,
            // this catch block handles it.

            // Set response content type to JSON
            context.Response.ContentType = "application/json";

            // Map custom exceptions to proper HTTP status codes
            context.Response.StatusCode = ex switch
            {
                // 409 = Conflict (used when stock is insufficient)
                InsufficientStockException => StatusCodes.Status409Conflict,

                // 409 = Conflict (duplicate order case)
                DuplicateOrderException => StatusCodes.Status409Conflict,

                // 400 = Bad Request (invalid state transition)
                InvalidOrderStateException => StatusCodes.Status400BadRequest,

                // 500 = Internal Server Error (any other unknown error)
                _ => StatusCodes.Status500InternalServerError
            };

            // Create a response object to send back to the client
            var result = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };

            // Convert object to JSON and send it in response body
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(result)
            );
        }
    }
}