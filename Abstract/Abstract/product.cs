using System;

namespace Abstract
{
    // Abstract class
    abstract class Product
    {
        // Fields
        public string Name;
        public double Price;

        // Abstract method (no body)
        public abstract double GetDiscountedPrice();

        // Normal method
        public void Display()
        {
            Console.WriteLine("Product Name: " + Name);
            Console.WriteLine("Product Price: " + Price);
        }
    }

    // Derived class
    class Electronics : Product
    {
        public override double GetDiscountedPrice()
        {
            return Price * 0.90;   // 10% discount
        }
    }
}
