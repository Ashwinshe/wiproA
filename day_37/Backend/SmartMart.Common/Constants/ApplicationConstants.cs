namespace SmartMart.Common.Constants;

// Static class used to store constant values
// These values are shared across the entire application.

public static class ApplicationConstants
{
    // Default threshold used to determine when stock is considered low.
    // Example: If QuantityAvailable < 5 → show Low Stock warning.
    public const int DefaultLowStockThreshold = 5;

    // Default status assigned to a new order when it is created.
    // Instead of hardcoding "Pending" in multiple places,
    // we define it once here.
    public const string DefaultOrderStatus = "Pending";

    // Represents the system user name used for
    // logging, auditing, or automated system actions.
    public const string SystemUser = "SmartMartSystem";
}