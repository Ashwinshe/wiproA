export function renderHome(stats: any): string {
    return `
        <h2 class="mb-4">Retail Operations Dashboard</h2>

        <div class="row g-4">

            <div class="col-md-4">
                <div class="card shadow p-4 text-center">
                    <h6>Total Products</h6>
                    <h2>${stats.totalProducts}</h2>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card shadow p-4 text-center">
                    <h6>Pending Orders</h6>
                    <h2>${stats.pendingOrders}</h2>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card shadow p-4 text-center">
                    <h6>Low Stock Alerts</h6>
                    <h2>${stats.lowStock}</h2>
                </div>
            </div>

        </div>
    `;
}