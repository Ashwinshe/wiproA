using System;

namespace day_10
{
    public class Calculator   // UUT
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Add(10, 5));
        }
    }
}
