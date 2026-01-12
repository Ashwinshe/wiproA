// using System;
// using Config;
// using Models;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Platform: " + AppConfig.PlatformName);
//         Console.WriteLine("Max Login Attempts: " + AppConfig.MaxLoginAttempts);
//         Console.WriteLine();

//         // Create users
//         User u1 = new User("Ashwin", "1234");
//         User u2 = new User("Ravi", "abcd");

//         Console.WriteLine("Total Registered Users: " + AppConfig.TotalUsers);
//         Console.WriteLine();

//         // Login simulation
//         u1.Login("1111");
//         u1.Login("2222");
//         u1.Login("3333");
//         u1.Login("1234");
//         u1.Login("1234");  // still locked

//         Console.WriteLine();

//         u2.Login("abcd");
//     }
// }

public enum OrderStatus
{
    Created,
    Paid,
    Shipped,
    Delivered,
    Cancelled
}
public struct DeliveryLocation
{
    public double Latitude;
    public double Longitude;

    public DeliveryLocation(double lat, double lng)
    {
        Latitude = lat;
        Longitude = lng;
    }
}
public interface IPayment
{
    void Pay(double amount);
}

public class CashPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid ₹{amount} using Cash.");
    }
}

public class UpiPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid ₹{amount} using UPI.");
    }
}
public class Order
{
    public int OrderId { get; set; }
    public double Amount { get; set; }
    public OrderStatus Status { get; private set; }
    public DeliveryLocation Location { get; set; }

    public Order(int id, double amount, DeliveryLocation location)
    {
        OrderId = id;
        Amount = amount;
        Location = location;
        Status = OrderStatus.Created;
    }

    public void MakePayment(IPayment payment)
    {
        payment.Pay(Amount);
        Status = OrderStatus.Paid;
    }

    public void Ship()
    {
        Status = OrderStatus.Shipped;
    }

    public void Deliver()
    {
        Status = OrderStatus.Delivered;
    }
}

class Program
{
    static void Main()
    {
        DeliveryLocation location = new DeliveryLocation(18.5204, 73.8567);

        Order order = new Order(101, 2500, location);

        Console.WriteLine("Order Created. Status: " + order.Status);

        IPayment payment = new UpiPayment();   // or new CashPayment();
        order.MakePayment(payment);

        Console.WriteLine("Status after payment: " + order.Status);

        order.Ship();
        Console.WriteLine("Status after shipping: " + order.Status);

        order.Deliver();
        Console.WriteLine("Final Status: " + order.Status);
    }
}
