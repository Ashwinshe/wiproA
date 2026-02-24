export function renderProducts(products: any[]): string {

    if (!products || products.length === 0) {
        return `<h3>No products available.</h3>`;
    }

    let rows = "";

    products.forEach(product => {
        rows += `
            <tr>
                <td>${product.productId}</td>
                <td>${product.name}</td>
                <td>${product.price}</td>
                <td>${product.inventory?.quantityAvailable ?? 0}</td>
            </tr>
        `;
    });

    return `
        <table class="table">
            <tbody>${rows}</tbody>
        </table>
    `;
}