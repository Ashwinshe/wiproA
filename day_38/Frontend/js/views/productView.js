export function renderProducts(products) {
    if (!products || products.length === 0) {
        return `<h3>No products available.</h3>`;
    }
    let rows = "";
    products.forEach(product => {
        var _a, _b;
        rows += `
            <tr>
                <td>${product.productId}</td>
                <td>${product.name}</td>
                <td>${product.price}</td>
                <td>${(_b = (_a = product.inventory) === null || _a === void 0 ? void 0 : _a.quantityAvailable) !== null && _b !== void 0 ? _b : 0}</td>
            </tr>
        `;
    });
    return `
        <table class="table">
            <tbody>${rows}</tbody>
        </table>
    `;
}
//# sourceMappingURL=productView.js.map