using System;
using Abstract;

class Program
{
    static void Main()
    {
        Electronics e1 = new Electronics();

        e1.Name = "Laptop";
        e1.Price = 50000;

        e1.Display();
        Console.WriteLine("Discounted Price: " + e1.GetDiscountedPrice());
    }
}
