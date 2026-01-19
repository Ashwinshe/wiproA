// See https://aka.ms/new-console-template for more information

// using System;

// class BubbleSort
// {
//     static void Main()
//     {
//         int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

//         for (int i = 0; i < arr.Length - 1; i++)
//         {
//             for (int j = 0; j < arr.Length - i - 1; j++)
//             {
//                 if (arr[j] > arr[j + 1])
//                 {
//                     // Swap
//                     int temp = arr[j];
//                     arr[j] = arr[j + 1];
//                     arr[j + 1] = temp;
//                 }
//             }
//         }

//         Console.WriteLine("Sorted Array:");
//         foreach (int num in arr)
//         {
//             Console.Write(num + " ");
//         }
//     }
// }
//    using System;

// class SelectionSort
// {
//     static void Main()
//     {
//         int[] arr = { 64, 25, 12, 22, 11 };

//         for (int i = 0; i < arr.Length - 1; i++)
//         {
//             int minIndex = i;

//             for (int j = i + 1; j < arr.Length; j++)
//             {
//                 if (arr[j] < arr[minIndex])
//                     minIndex = j;
//             }

//             int temp = arr[minIndex];
//             arr[minIndex] = arr[i];
//             arr[i] = temp;
//         }

//         Console.WriteLine("Sorted Array:");
//         foreach (int num in arr)
//             Console.Write(num + " ");
//     }
// // }

// using System;

// class InsertionSort
// {
//     static void Main()
//     {
//         int[] arr = { 12, 11, 13, 5, 6 };

//         for (int i = 1; i < arr.Length; i++)
//         {
//             int key = arr[i];
//             int j = i - 1;

//             while (j >= 0 && arr[j] > key)
//             {
//                 arr[j + 1] = arr[j];
//                 j--;
//             }

//             arr[j + 1] = key;
//         }

//         Console.WriteLine("Sorted Array:");
//         foreach (int num in arr)
//             Console.Write(num + " ");
//     }
// }


// using System;

// class SortingCaseStudy
// {
//     static void Main()
//     {
//         // Student Marks (Counting Sort)
//         int[] marks = { 78, 95, 45, 62, 78, 90, 45 };
//         Console.WriteLine("Original Marks:");
//         PrintArray(marks);

//         CountingSort(marks, 100);

//         Console.WriteLine("\nSorted Marks (Counting Sort):");
//         PrintArray(marks);

//         // Registration Numbers (Radix Sort)
//         int[] regNumbers = { 102345, 984321, 345678, 123456, 567890 };
//         Console.WriteLine("\nOriginal Registration Numbers:");
//         PrintArray(regNumbers);

//         RadixSort(regNumbers);

//         Console.WriteLine("\nSorted Registration Numbers (Radix Sort):");
//         PrintArray(regNumbers);
//     }

//     // PRINT ARRAY
//     static void PrintArray(int[] arr)
//     {
//         foreach (int num in arr)
//             Console.Write(num + " ");
//         Console.WriteLine();
//     }

//     // COUNTING SORT 
//     static void CountingSort(int[] arr, int maxValue)
//     {
//         int[] count = new int[maxValue + 1];

//         foreach (int num in arr)
//             count[num]++;

//         int index = 0;
//         for (int i = 0; i <= maxValue; i++)
//         {
//             while (count[i] > 0)
//             {
//                 arr[index++] = i;
//                 count[i]--;
//             }
//         }
//     }

//     // RADIX SORT 
//     static void RadixSort(int[] arr)
//     {
//         int max = GetMax(arr);

//         for (int exp = 1; max / exp > 0; exp *= 10)
//             CountSortByDigit(arr, exp);
//     }

//     static int GetMax(int[] arr)
//     {
//         int max = arr[0];
//         foreach (int num in arr)
//             if (num > max) max = num;
//         return max;
//     }

//     static void CountSortByDigit(int[] arr, int exp)
//     {
//         int n = arr.Length;
//         int[] output = new int[n];
//         int[] count = new int[10];

//         for (int i = 0; i < n; i++)
//             count[(arr[i] / exp) % 10]++;

//         for (int i = 1; i < 10; i++)
//             count[i] += count[i - 1];

//         for (int i = n - 1; i >= 0; i--)
//         {
//             int digit = (arr[i] / exp) % 10;
//             output[count[digit] - 1] = arr[i];
//             count[digit]--;
//         }

//         for (int i = 0; i < n; i++)
//             arr[i] = output[i];
//     }
// }



// Index
using System.Dynamic;
using System.Globalization;

class Program
{
    static void Main()
    {
        // creating a object hold data using indexers
        StudentMarks students = new StudentMarks();// simple object of the student marks
        students.StudentName = "Ashwin";
        Console.WriteLine("My name is: ");
         Console.WriteLine(students.StudentName);

        // Using indexer to set values
        students[0] = 90;
        students[1] = 100;
        students[2] = 200;
        students[3] = 160;
       // students.Clgname = "IIT Delhi";

        Console.WriteLine("Student Marks:");
        Console.WriteLine(students[0]);
        Console.WriteLine(students[1]);
        Console.WriteLine(students[2]);
        Console.WriteLine(students[3]);
       
    }
}
class StudentMarks
{
    public string StudentName{get; set;} // simple property
    private int[] marks = new int[5];   // internal array
    // indexers array like access to marks

    
    
    // Indexer
    public int this[int subjectIndex]
    {
        get
        {
            return marks[subjectIndex];
        }
        set
        {
            marks[subjectIndex] = value;
        }
    }
}

