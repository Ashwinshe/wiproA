// See https:aka.ms/new-console-template for more information
// using System;

// Console.WriteLine("Enter a number:");

// try
// {
//     int divisor = int.Parse(Console.ReadLine());   // convert string → int
//     int result = 100 / divisor;
//     Console.WriteLine("Result = " + result);
// }
// catch (DivideByZeroException)
// {
//     Console.WriteLine("You cannot divide by zero.");
// }
// catch (FormatException)
// {
//     Console.WriteLine("Please enter a valid number.");
// }
// catch (Exception ex)
// {
//     Console.WriteLine("Error: " + ex.Message);
// }

// using System;

//  Custom Exception
// public class DailyLimitExceededException : Exception
// {
//     public DailyLimitExceededException(string message) : base(message)
//     {
//     }
// }

// //  Business Logic Class
// class BankAccount
// {
//     private decimal dailyLimit = 1000;
//     private decimal totalTransactionsToday = 0;

//     public void MakeTransaction(decimal amount)
//     {
//         if (totalTransactionsToday + amount > dailyLimit)
//         {
//             throw new DailyLimitExceededException("Daily transaction limit exceeded.");
//         }

//         totalTransactionsToday += amount;
//         Console.WriteLine($"Transaction of {amount} completed successfully.");
//     }
// }

// //  Main Program
// class Program
// {
//     static void Main()
//     {
//         BankAccount account = new BankAccount();

//         try
//         {
//             account.MakeTransaction(400);
//             account.MakeTransaction(300);
//             account.MakeTransaction(500);   // This will throw exception
//         }
//         catch (DailyLimitExceededException ex)
//         {
//             Console.WriteLine("Custom Error: " + ex.Message);
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("General Error: " + ex.Message);
//         }
//     }
// }
// // User input problems (DO NOT LOG)
// using System;
// using System.ComponentModel;
// using System.Data;
// using System.Data.SqlTypes;
// using System.Diagnostics;
// using System.Reflection.Emit;
// using System.Runtime.CompilerServices;
// using System.Runtime.InteropServices.Marshalling;

// // Custom Exceptions

// class ValidationException : Exception
// {
//     public ValidationException(string msg) : base(msg) { }
// }

// class BusinessRuleException : Exception
// {
//     public BusinessRuleException(string msg) : base(msg) { }
// }

// class ExternalServiceException : Exception
// {
//     public ExternalServiceException(string msg) : base(msg) { }
// }

// //  Logger
// static class Logger
// {
//     public static void Log(Exception ex)
//     {
//         Console.ForegroundColor = ConsoleColor.Red;
//         Console.WriteLine($"[{DateTime.Now}] {ex.GetType().Name} : {ex.Message}");
//         Console.ResetColor();
//     }
// }

// //  Business Service
// class OrderService
// {
//     public void PlaceOrder(int quantity, bool paymentServiceDown)
//     {
//         if (quantity <= 0)
//             throw new ValidationException("Quantity must be greater than zero");

//         if (quantity > 10)
//             throw new BusinessRuleException("Insufficient stock");

//         if (paymentServiceDown)
//             throw new ExternalServiceException("Payment gateway unavailable");

//         Console.WriteLine("Order placed successfully!");
//     }
// }

// //  Program
// class Program
// {
//     static void Main()
//     {
//         var service = new OrderService();

//         try
//         {
//             int num = int.Parse(Console.ReadLine());
//             bool n = bool.Parse(Console.ReadLine());
//             service.PlaceOrder(num, n);   // Change to test
//         }
//         catch (Exception ex) when (!LogIfRequired(ex))
//         {
//             Console.WriteLine("Validation error handled without logging");
//         }
//         catch (Exception)
//         {
//             Console.WriteLine("Critical failure handled after logging");
//         }
//     }

//     //  Exception Filter
//     static bool LogIfRequired(Exception ex)
//     {
//         if (ex is ValidationException)
//             return false;   // skip logging

//         Logger.Log(ex);     // log critical failures
//         return true;
//     }
// }
//creating a file using File.Create() method in default directory
// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         string folder = "Data";                 // safe folder
//         Directory.CreateDirectory(folder);      // create if not exists

//         string filePath = Path.Combine(folder, "demo.txt");

//         using (StreamWriter sw = new StreamWriter(filePath))
//         {
//             sw.WriteLine("Hello from Day 5");
//             sw.WriteLine("This file was created by C#");
//         }

//         Console.WriteLine("File created at: " + filePath);
//     }
// }
// //creating a file using File.Create() method in default directory


// output in bin..
string filePath = "demo.txt";
using (FileStream fs = File.Create(filePath))
{
    // File created successfully
    if (File.Exists(filePath))
    {
        Console.WriteLine("File created successfully: " + filePath);
    }
}

//Writing to the file using StreamWriter class
using (StreamWriter sw = new StreamWriter(filePath))
{
    sw.WriteLine("Hello, this is a demo file created today.");
    sw.WriteLine("This file is created to demonstrate file handling in C#.");
}
