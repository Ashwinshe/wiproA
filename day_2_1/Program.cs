// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orderList = new List<Order>();

            orderList.Add(new Order
            {
                OrderId = 1,
                ProductName = "Laptop",
                Quantity = 2,
                Price = 1500
            });

            orderList.Add(new Order
            {
                OrderId = 2,
                ProductName = "Mobile",
                Quantity = 5,
                Price = 800
            });

            Console.WriteLine("Orders in the Order Collection:");
            foreach (var order in orderList)
            {
                Console.WriteLine(order);
            }

            Console.ReadLine(); 
        }
    }
}
