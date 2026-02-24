// Base URL of ASP.NET Core Backend API
const BASE_URL = "http://localhost:5230/api";


// Fetches all products from backend
// Endpoint: GET /api/products

export async function getProducts() {

    try {
        // Sending GET request to backend
        const response = await fetch(`${BASE_URL}/products`);

        // If response is not successful, throw error
        if (!response.ok) {
            throw new Error("Failed to fetch products");
        }

        // Convert response to JSON
        const data = await response.json();

        // Return product list
        return data;

    } catch (error) {
        console.error("Error fetching products:", error);
        alert("Unable to load products from server.");
    }
}


// Sends new order to backend
// Endpoint: POST /api/orders
export async function createOrder(order: any) {

    try {
        const response = await fetch(`${BASE_URL}/orders`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            // Convert order object to JSON string
            body: JSON.stringify(order)
        });

        if (!response.ok) {
            throw new Error("Order creation failed");
        }

        const result = await response.json();

        return result;

    } catch (error) {
        console.error("Error creating order:", error);
        alert("Order could not be created.");
    }
}



// Updates stock quantity
// Endpoint: PUT /api/inventory
export async function updateInventory(updateData: any) {

    const response = await fetch(
        `${BASE_URL}/inventory/update-stock?productId=${updateData.productId}&quantity=${updateData.quantityChange}`,
        {
            method: "PUT"
        }
    );

    if (!response.ok) {
        throw new Error("Inventory update failed");
    }

    return await response.text();
}
// Frontend (TypeScript)
//         ↓
// fetch()
//         ↓
// ASP.NET Core Controller
//         ↓
// Service Layer
//         ↓
// DbContext (SQL Server)