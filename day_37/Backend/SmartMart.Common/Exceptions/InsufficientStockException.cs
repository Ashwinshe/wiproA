namespace SmartMart.Common.Exceptions;

// Custom exception thrown when requested quantity
// is greater than available stock.
public class InsufficientStockException : Exception
{
    // Default constructor with predefined message
    public InsufficientStockException()
        : base("Insufficient stock available.")
    {
    }

    // Constructor that allows a custom error message
    public InsufficientStockException(string message)
        : base(message)
    {
    }
}