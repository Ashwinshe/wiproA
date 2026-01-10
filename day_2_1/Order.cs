namespace ConsoleApp2
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, ProductName: {ProductName}, Quantity: {Quantity}, Price: {Price}";
        }
    }
}
