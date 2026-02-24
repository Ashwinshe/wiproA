export function renderInventoryForm(): string {

    return `
        <h2 class="mb-4">Update Inventory</h2>

        <form id="inventoryForm" class="shadow p-4 bg-white rounded">

            <!-- Product ID -->
            <div class="mb-3">
                <label class="form-label">Product ID</label>
                <input 
                    type="number" 
                    id="invProductId" 
                    class="form-control" 
                    required>
            </div>

            <!-- Quantity Change -->
            <div class="mb-3">
                <label class="form-label">
                    Quantity Adjustment (+/-)
                </label>
                <input 
                    type="number" 
                    id="invQuantity" 
                    class="form-control" 
                    required>
            </div>

            <button type="submit" class="btn btn-success">
                Update Stock
            </button>

        </form>
    `;
}