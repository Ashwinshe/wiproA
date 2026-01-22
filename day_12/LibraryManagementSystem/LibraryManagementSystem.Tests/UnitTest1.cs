using NUnit.Framework;
using LibraryManagementSystem;

namespace LibraryManagementSystem.Tests
{
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void AddBook_ShouldAddBook()
        {
            var book = new Book("Clean Code", "Robert Martin", "101");

            library.AddBook(book);

            Assert.That(library.Books.Count, Is.EqualTo(1));
        }

        [Test]
        public void RegisterBorrower_ShouldAddBorrower()
        {
            var borrower = new Borrower("Ashwin", "CARD01");

            library.RegisterBorrower(borrower);

            Assert.That(library.Borrowers.Count, Is.EqualTo(1));
        }

        [Test]
        public void BorrowBook_ShouldMarkBookAsBorrowed()
        {
            var book = new Book("C#", "Jon Skeet", "102");
            var borrower = new Borrower("Ravi", "CARD02");

            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("102", "CARD02");

            Assert.That(book.IsBorrowed, Is.True);
            Assert.That(borrower.BorrowedBooks.Count, Is.EqualTo(1));
        }

        [Test]
        public void ReturnBook_ShouldMakeBookAvailable()
        {
            var book = new Book("Design Patterns", "GoF", "103");
            var borrower = new Borrower("Anu", "CARD03");

            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("103", "CARD03");
            library.ReturnBook("103", "CARD03");

            Assert.That(book.IsBorrowed, Is.False);
            Assert.That(borrower.BorrowedBooks.Count, Is.EqualTo(0));
        }
    }
}
