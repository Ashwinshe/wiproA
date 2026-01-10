// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("Please enter your name.");
// String name = Console.ReadLine();
// Console.WriteLine("Hello, " + name);
Console.WriteLine("Please enter your age:");
string ageIn = Console.ReadLine();

int age;
bool isValid = int.TryParse(ageIn, out age);

if (isValid)
{
    if (age >= 18)
    {
        Console.WriteLine("Eligible");
    }
    else
    {
        Console.WriteLine("Not eligible");
    }
}
else
{
    Console.WriteLine("Invalid input");
}
