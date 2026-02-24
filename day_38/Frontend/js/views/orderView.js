export function renderOrderForm() {
    return `
        <h2 class="mb-4">Create Order</h2>

        <form id="orderForm" class="shadow p-4 bg-white rounded">

            <!-- Product ID Input -->
            <div class="mb-3">
                <label class="form-label">Product ID</label>
                <input 
                    type="number" 
                    id="productId" 
                    class="form-control" 
                    required>
            </div>

            <!-- Quantity Input -->
            <div class="mb-3">
                <label class="form-label">Quantity</label>
                <input 
                    type="number" 
                    id="quantity" 
                    class="form-control" 
                    min="1"
                    required>
            </div>

            <button type="submit" class="btn btn-primary">
                Submit Order
            </button>

        </form>
    `;
}
//# sourceMappingURL=orderView.js.map