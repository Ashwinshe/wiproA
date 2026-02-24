// Responsible for:
// 1. Navigation handling
// 2. Calling API services
// 3. Binding form events
// 4. Connecting views with backend
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var _a, _b, _c, _d;
import { loadView } from "./router.js";
import { renderHome } from "./views/homeView.js";
import { renderProducts } from "./views/productView.js";
import { renderOrderForm } from "./views/orderView.js";
import { renderInventoryForm } from "./views/inventoryView.js";
import { getProducts, createOrder, updateInventory } from "./services/apiService.js";
// Products
(_a = document.getElementById("navProducts")) === null || _a === void 0 ? void 0 : _a.addEventListener("click", () => __awaiter(void 0, void 0, void 0, function* () {
    // Fetch product data from backend
    const products = yield getProducts();
    // Render view with backend data
    loadView(renderProducts(products));
}));
// Create Order
(_b = document.getElementById("navOrders")) === null || _b === void 0 ? void 0 : _b.addEventListener("click", () => {
    loadView(renderOrderForm());
    // Attach form submit event AFTER rendering
    bindOrderForm();
});
// Inventory Update
(_c = document.getElementById("navInventory")) === null || _c === void 0 ? void 0 : _c.addEventListener("click", () => {
    loadView(renderInventoryForm());
    // Attach form submit event AFTER rendering
    bindInventoryForm();
});
function bindOrderForm() {
    const form = document.getElementById("orderForm");
    form === null || form === void 0 ? void 0 : form.addEventListener("submit", (event) => __awaiter(this, void 0, void 0, function* () {
        event.preventDefault(); // Prevent page reload
        // Get input values
        const productId = parseInt(document.getElementById("productId").value);
        const quantity = parseInt(document.getElementById("quantity").value);
        // Create type-safe Order object
        const order = {
            items: [
                {
                    productId: productId,
                    quantity: quantity
                }
            ]
        };
        // Send to backend
        const result = yield createOrder(order);
        alert("Order Created Successfully! ID: " + (result === null || result === void 0 ? void 0 : result.orderId));
    }));
}
function bindInventoryForm() {
    const form = document.getElementById("inventoryForm");
    form === null || form === void 0 ? void 0 : form.addEventListener("submit", (event) => __awaiter(this, void 0, void 0, function* () {
        event.preventDefault();
        const productId = parseInt(document.getElementById("invProductId").value);
        const quantityChange = parseInt(document.getElementById("invQuantity").value);
        // Create type-safe InventoryUpdate object
        const updateData = {
            productId: productId,
            quantityChange: quantityChange
        };
        // Send update to backend
        yield updateInventory(updateData);
        alert("Inventory Updated Successfully!");
    }));
}
(_d = document.getElementById("navHome")) === null || _d === void 0 ? void 0 : _d.addEventListener("click", () => __awaiter(void 0, void 0, void 0, function* () {
    const products = yield getProducts();
    const totalProducts = products.length;
    const lowStock = products.filter((p) => { var _a; return ((_a = p.inventory) === null || _a === void 0 ? void 0 : _a.quantityAvailable) < 10; }).length;
    const stats = {
        totalProducts,
        pendingOrders: 0, // until you connect orders API
        lowStock
    };
    loadView(renderHome(stats));
}));
//# sourceMappingURL=main.js.map