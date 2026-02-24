export interface InventoryUpdate {

    // Product whose inventory is being updated
    productId: number;

    // Quantity change (+ for increase, - for decrease)
    quantityChange: number;
}