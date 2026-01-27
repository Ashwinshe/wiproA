//See https:aka.ms/new-console-template for more information
// using System;
// using System.Collections.Generic;
// using System.Collections; // Non-Generic Stack

// // Generic
// class Program
// {
//     static void Main()
//     {
//         Stack<int> numbers = new Stack<int>();

//         numbers.Push(10);  
//         numbers.Push(20);
//         numbers.Push(30);


//         Console.WriteLine(numbers.Pop());   
//         Console.WriteLine(numbers.Peek());  
//         Console.WriteLine(numbers.Count);   
//     }
// }


// // Non-Generic Stack

// class Program
// {
//     static void Main()
//     {
//         Stack s = new Stack();

//         s.Push(10);
//         s.Push("Hello");
//         s.Push(3.5);

//         Console.WriteLine(s.Pop());  // 3.5
//         Console.WriteLine(s.Pop());  // Hello
//     }
// }

//Enterprise Course Platform

// using System;
// using System.Collections.Generic;

// class Course
// {
//     public string Code { get; set; }
//     public string Name { get; set; }

//     public Course(string code, string name)
//     {
//         Code = code;
//         Name = name;
//     }

//     public override string ToString()
//     {
//         return $"{Code} - {Name}";
//     }
// }

// class EnrollmentRequest
// {
//     public int StudentId { get; set; }
//     public string CourseCode { get; set; }

//     public EnrollmentRequest(int studentId, string courseCode)
//     {
//         StudentId = studentId;
//         CourseCode = courseCode;
//     }
// }

// class AdminAction
// {
//     public string Action { get; set; }
//     public AdminAction(string action)
//     {
//         Action = action;
//     }
// }

// class Program
// {
//     static List<Course> courseCatalog = new List<Course>();
//     static Dictionary<string, Course> courseLookup = new Dictionary<string, Course>();
//     static HashSet<int> enrolledStudents = new HashSet<int>();
//     static Queue<EnrollmentRequest> enrollmentQueue = new Queue<EnrollmentRequest>();
//     static Stack<AdminAction> adminActions = new Stack<AdminAction>();
//     static SortedList<DateTime, string> sessions = new SortedList<DateTime, string>();

//     static void Main()
//     {
//         // Add courses
//         AddCourse(new Course("CS101", "C# Basics"));
//         AddCourse(new Course("JS201", "JavaScript"));

//         // Add training sessions
//         sessions.Add(DateTime.Parse("2026-01-20 10:00"), "C# Basics");
//         sessions.Add(DateTime.Parse("2026-01-18 09:00"), "JavaScript");

//         // Enrollment requests
//         enrollmentQueue.Enqueue(new EnrollmentRequest(1, "CS101"));
//         enrollmentQueue.Enqueue(new EnrollmentRequest(2, "JS201"));
//         enrollmentQueue.Enqueue(new EnrollmentRequest(1, "CS101")); // duplicate

//         // Process enrollment
//         ProcessEnrollments();

//         // Show sessions sorted
//         ShowSessions();

//         // Undo admin action
//         UndoLastAction();
//     }

//     static void AddCourse(Course course)
//     {
//         courseCatalog.Add(course);                 // List
//         courseLookup[course.Code] = course;        // Dictionary
//         adminActions.Push(new AdminAction($"Added Course {course.Code}")); // Stack
//     }

//     static void ProcessEnrollments()
//     {
//         Console.WriteLine("Enrollment Processing:");
//         while (enrollmentQueue.Count > 0)
//         {
//             var req = enrollmentQueue.Dequeue();   // Queue (FIFO)

//             if (enrolledStudents.Add(req.StudentId)) // HashSet (No duplicates)
//             {
//                 Console.WriteLine($"Student {req.StudentId} enrolled in {req.CourseCode}");
//             }
//             else
//             {
//                 Console.WriteLine($"Duplicate enrollment blocked for Student {req.StudentId}");
//             }
//         }
//     }

//     static void ShowSessions()
//     {
//         Console.WriteLine("\nSessions Sorted by Time:");
//         foreach (var s in sessions)                // SortedList
//         {
//             Console.WriteLine($"{s.Key} -> {s.Value}");
//         }
//     }

//     static void UndoLastAction()
//     {
//         Console.WriteLine("\nUndo Last Admin Action:");
//         if (adminActions.Count > 0)
//         {
//             Console.WriteLine(adminActions.Pop().Action);
//         }
//     }
// }

//lambda expressions


// Func<int, int> square = x => x * x;
// Func<int, int, int> add = (a, b) => a + b;
// Action<string> print = s => Console.WriteLine(s);

// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int> { 3, 5, 81, 45, 32, 15, 70 };

//         Console.WriteLine("All numbers in the list:");
//         foreach (int number in numbers)
//         {
//             Console.WriteLine(number);
//         }

//         Console.WriteLine("Even number :");

//         var res = numbers.Where(n => n % 2 == 0);
//         foreach(var n in res)
//         {
//             Console.WriteLine(n);
//         }
//         Console.WriteLine("\nNumbers greater than 10 (using lambda expression):");
//         var result = numbers.Where(n => n > 10);
        
//         foreach (var num in result)
//         {
//             Console.WriteLine(num);
//         }
//     }
// }
   
using System;

namespace day_6
{
    // ORDER STATUS
    enum OrderStatus
    {
        New,
        Processing,
        Completed,
        Cancelled
    }

    class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public OrderStatus Status { get; set; }
    }

    static class OrderExtensions
    {
        public static double ApplyDiscount(this Order order)
            => order.Price > 1000 ? order.Price * 0.90 : order.Price;
    }

    class PricingService
    {
        public (double price, double tax, double discount) CalculatePrice(Order order)
        {
            double tax = order.Price * 0.18;
            double discount = order.Price > 500 ? 50 : 0;
            return (order.Price, tax, discount);
        }
    }

    class Inventory
    {
        private int[] stock = { 200 };

        public ref int GetStockRef() => ref stock[0];

        public bool ValidateStock(int quantity, out string message)
        {
            bool IsAvailable() => quantity <= stock[0]; // Local function

            if (IsAvailable())
            {
                message = "Stock available";
                return true;
            }

            message = "Not enough stock";
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            Order order = new Order
            {
                Id = 1,
                Price = 1200,
                Status = OrderStatus.Processing
            };

            PricingService pricing = new PricingService();
            Inventory inventory = new Inventory();

            string orderMessage = order.Status switch
            {
                OrderStatus.New => "New order created",
                OrderStatus.Processing => "Order is processing",
                OrderStatus.Completed => "Order completed",
                OrderStatus.Cancelled => "Order cancelled",
                _ => "Unknown status"
            };

            Console.WriteLine(orderMessage);

            var (price, tax, discount) = pricing.CalculatePrice(order);

            var (_, _, onlyDiscount) = pricing.CalculatePrice(order);

            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Tax: {tax}");
            Console.WriteLine($"Discount: {onlyDiscount}");

            Console.WriteLine($"Final Price After Discount: {order.ApplyDiscount()}");

            if (inventory.ValidateStock(50, out string msg))
                Console.WriteLine(msg);

            ref int stock = ref inventory.GetStockRef();
            stock -= 50;

            Console.WriteLine($"Remaining Stock: {stock}");
        }
    }
}
