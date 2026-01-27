// See https://aka.ms/new-console-template for more information
using System;

class Employee
{
    // Properties
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }

    // Private array for attendance
    private int[] attendance = new int[12];

    // Indexer
    public int this[int month]
    {
        get { return attendance[month]; }
        set { attendance[month] = value; }
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();
        emp.EmployeeId = 101;
        emp.EmployeeName = "Ashwin";

        // Using indexer
        emp[0] = 22; // January attendance

        Console.WriteLine(emp.EmployeeName);
        Console.WriteLine("January Attendance: " + emp[0]);
    }
}
class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }

    private int[] ratings = new int[5];

    public int this[int customerIndex]
    {
        get { return ratings[customerIndex]; }
        set { ratings[customerIndex] = value; }
    }
}

