
// Responsible for:
// 1. Navigation handling
// 2. Calling API services
// 3. Binding form events
// 4. Connecting views with backend


import { loadView } from "./router.js";

import { renderHome } from "./views/homeView.js";
import { renderProducts } from "./views/productView.js";
import { renderOrderForm } from "./views/orderView.js";
import { renderInventoryForm } from "./views/inventoryView.js";

import { getProducts, createOrder, updateInventory } from "./services/apiService.js";

import { Order } from "./models/order.js";
import { InventoryUpdate } from "./models/inventory.js";




// Products
document.getElementById("navProducts")?.addEventListener("click", async () => {

    // Fetch product data from backend
    const products = await getProducts();

    // Render view with backend data
    loadView(renderProducts(products));
});

// Create Order
document.getElementById("navOrders")?.addEventListener("click", () => {

    loadView(renderOrderForm());

    // Attach form submit event AFTER rendering
    bindOrderForm();
});

// Inventory Update
document.getElementById("navInventory")?.addEventListener("click", () => {

    loadView(renderInventoryForm());

    // Attach form submit event AFTER rendering
    bindInventoryForm();
});


function bindOrderForm(): void {

    const form = document.getElementById("orderForm");

    form?.addEventListener("submit", async (event) => {

        event.preventDefault(); // Prevent page reload

        // Get input values
        const productId = parseInt(
            (document.getElementById("productId") as HTMLInputElement).value
        );

        const quantity = parseInt(
            (document.getElementById("quantity") as HTMLInputElement).value
        );

        // Create type-safe Order object
        const order: Order = {
            items: [
                {
                    productId: productId,
                    quantity: quantity
                }
            ]
        };

        // Send to backend
        const result = await createOrder(order);

        alert("Order Created Successfully! ID: " + result?.orderId);
    });
}


function bindInventoryForm(): void {

    const form = document.getElementById("inventoryForm");

    form?.addEventListener("submit", async (event) => {

        event.preventDefault();

        const productId = parseInt(
            (document.getElementById("invProductId") as HTMLInputElement).value
        );

        const quantityChange = parseInt(
            (document.getElementById("invQuantity") as HTMLInputElement).value
        );

        // Create type-safe InventoryUpdate object
        const updateData: InventoryUpdate = {
            productId: productId,
            quantityChange: quantityChange
        };

        // Send update to backend
        await updateInventory(updateData);

        alert("Inventory Updated Successfully!");
    });
}

document.getElementById("navHome")?.addEventListener("click", async () => {

    const products = await getProducts();

    const totalProducts = products.length;

    const lowStock = products.filter((p: any) =>
        p.inventory?.quantityAvailable < 10
    ).length;

    const stats = {
        totalProducts,
        pendingOrders: 0, // until you connect orders API
        lowStock
    };

    loadView(renderHome(stats));
});