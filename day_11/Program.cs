// // See https://aka.ms/new-console-template for more information

// using System;
// using System.Linq;

// public class StudentMarksCalculator
// {
//     public int CalculateTotal(int[] marks)
//     {
//         ValidateMarks(marks);
//         return marks.Sum();
//     }

//     public double CalculateAverage(int[] marks)
//     {
//         ValidateMarks(marks);
//         return marks.Average();
//     }

//     public string CalculateGrade(int[] marks)
//     {
//         double average = CalculateAverage(marks);

//         if (average >= 80) return "A";
//         if (average >= 60) return "B";
//         if (average >= 40) return "C";
//         return "Fail";
//     }

//     private void ValidateMarks(int[] marks)
//     {
//         if (marks == null || marks.Length != 3)
//             throw new ArgumentException("Invalid input");

//         if (marks.Any(m => m < 0))
//             throw new ArgumentException("Negative marks not allowed");

//         if (marks.Any(m => m > 100))
//             throw new ArgumentException("Marks greater than 100 not allowed");
//     }
// }

// using System;
// using System.Security.Cryptography;
// using System.Text;

// class Program
// {
//     static void Main(string[] args)
//     {
//         string loginPassword = "MySecurePassword";
//         string storedHash;

//         // STEP 1: Hash the password (simulate stored hash)
//         using (SHA256 sha256 = SHA256.Create())
//         {
//             byte[] bytes = Encoding.UTF8.GetBytes(loginPassword);
//             byte[] hashBytes = sha256.ComputeHash(bytes);
//             storedHash = Convert.ToBase64String(hashBytes);
//         }

//         // STEP 2: Hash login password again
//         string loginHash;
//         using (SHA256 sha256 = SHA256.Create())
//         {
//             byte[] loginBytes = Encoding.UTF8.GetBytes(loginPassword);
//             byte[] loginHashBytes = sha256.ComputeHash(loginBytes);
//             loginHash = Convert.ToBase64String(loginHashBytes);
//         }

//         // STEP 3: Compare hashes
//         bool isValid = storedHash == loginHash;

//         Console.WriteLine("Password Match: " + isValid);
//     }
// }
using System;
using System.Speech.Synthesis;

class Program
{
    static void Main()
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        synth.Speak("Hello World");
    }
}
