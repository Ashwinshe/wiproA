using System;
using LibraryManagementSystem;

class Program
{
    static void Main()
    {
        Library library = new Library();

        Book book = new Book("Clean Code", "Robert Martin", "101");
        Borrower borrower = new Borrower("Ashwin", "CARD01");

        library.AddBook(book);
        library.RegisterBorrower(borrower);

        library.BorrowBook("101", "CARD01");

        Console.WriteLine($"Book Borrowed: {book.IsBorrowed}");
    }
}
