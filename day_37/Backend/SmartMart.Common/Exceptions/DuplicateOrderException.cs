namespace SmartMart.Common.Exceptions;

// Custom exception thrown when a duplicate order is detected.
// Inherits from the built-in System.Exception class.
public class DuplicateOrderException : Exception
{
    // Default constructor
    // Calls base class constructor with default error message
    public DuplicateOrderException()
        : base("Duplicate order detected.")
    {
    }

    // Constructor that allows passing a custom message
    // Useful when you want more detailed error information
    public DuplicateOrderException(string message)
        : base(message)
    {
    }
}