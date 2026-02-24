
export interface OrderItem {

    // ID of product being ordered
    productId: number;

    // Quantity ordered
    quantity: number;
}

export interface Order {

    // Array of ordered products
    items: OrderItem[];
}