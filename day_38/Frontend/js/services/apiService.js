var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
// Base URL of ASP.NET Core Backend API
const BASE_URL = "http://localhost:5230/api";
// Fetches all products from backend
// Endpoint: GET /api/products
export function getProducts() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            // Sending GET request to backend
            const response = yield fetch(`${BASE_URL}/products`);
            // If response is not successful, throw error
            if (!response.ok) {
                throw new Error("Failed to fetch products");
            }
            // Convert response to JSON
            const data = yield response.json();
            // Return product list
            return data;
        }
        catch (error) {
            console.error("Error fetching products:", error);
            alert("Unable to load products from server.");
        }
    });
}
// Sends new order to backend
// Endpoint: POST /api/orders
export function createOrder(order) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield fetch(`${BASE_URL}/orders`, {
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
            const result = yield response.json();
            return result;
        }
        catch (error) {
            console.error("Error creating order:", error);
            alert("Order could not be created.");
        }
    });
}
// Updates stock quantity
// Endpoint: PUT /api/inventory
export function updateInventory(updateData) {
    return __awaiter(this, void 0, void 0, function* () {
        const response = yield fetch(`${BASE_URL}/inventory/update-stock?productId=${updateData.productId}&quantity=${updateData.quantityChange}`, {
            method: "PUT"
        });
        if (!response.ok) {
            throw new Error("Inventory update failed");
        }
        return yield response.text();
    });
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
//# sourceMappingURL=apiService.js.map