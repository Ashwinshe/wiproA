namespace SmartMart.Common.Exceptions;

// Custom exception thrown when an invalid
// order status transition occurs.
// Example: Trying to move from Delivered → Pending.
public class InvalidOrderStateException : Exception
{
    // Default constructor with standard message
    public InvalidOrderStateException()
        : base("Invalid order state transition.")
    {
    }

    // Constructor allowing a custom message
    public InvalidOrderStateException(string message)
        : base(message)
    {
    }
}