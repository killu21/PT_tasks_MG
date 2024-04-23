using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace LibraryTests
{
    [TestFixture]
    public class EventsTests
    {
        private Events events;
        private Library.Library library;
        private User user;
        private Book book1;
        private Book book2;

        [SetUp]
        public void SetUp()
        {
            events = new Events();
            user = new Customer("Doe", "John", 1234567890, 1, 100);
            book1 = new Book(1, "Book1", "Author1", 30);
            book2 = new Book(2, "Book2", "Author2", 30);
            library = new Library.Library(2000);

            // Add books to the library after creating the Library object
            library.AddBook(book1);
            library.AddBook(book2);
        }

        [Test]
        public void AddBooksToCatalog_WithValidBooks_ShouldAddBooksToCatalog()
        {
            // Arrange
            Book book3 = new Book(3, "Book3", "Author3", 30);
            Book[] books = new Book[] { book3 };

            // Act
            events.AddBooksToCatalog(books, library);

            // Assert
            Assert.IsTrue(library.GetCatalog().GetBooks().Contains(book3));
        }

        [Test]
        public void RemoveBooksFromCatalog_WithValidBooks_ShouldRemoveBooksFromCatalog()
        {
            // Arrange
            Book book3 = new Book(3, "Book3", "Author3", 30);
            Book[] books = new Book[] { book3 };
            events.AddBooksToCatalog(books, library);

            // Act
            events.RemoveBooksFromCatalog(books, library);

            // Assert
            Assert.IsFalse(library.GetCatalog().GetBooks().Contains(book3));
        }
    }
}