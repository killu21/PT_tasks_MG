using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace LibraryTests
{
    [TestFixture]
    public class EventsTests
    {
        private Events _events;
        private Library.Library _library;
        private User _user;
        private Book _book1;
        private Book _book2;

        [SetUp]
        public void SetUp()
        {
            _events = new Events();
            _user = new Customer("Doe", "John", 1234567890, 1, 100);
            _book1 = new Book(1, "Book1", "Author1", 30);
            _book2 = new Book(2, "Book2", "Author2", 30);
            _library = new Library.Library(2000);

            // Add books to the library after creating the Library object
            _library.AddBook(_book1);
            _library.AddBook(_book2);
        }

        [Test]
        public void AddBooksToCatalog_WithValidBooks_ShouldAddBooksToCatalog()
        {
            // Arrange
            Book book3 = new Book(3, "Book3", "Author3", 30);
            Book[] books = new Book[] { book3 };

            // Act
            _events.AddBooksToCatalog(books, _library);

            // Assert
            Assert.IsTrue(_library.GetCatalog().GetBooks().Contains(book3));
        }

        [Test]
        public void RemoveBooksFromCatalog_WithValidBooks_ShouldRemoveBooksFromCatalog()
        {
            // Arrange
            Book book3 = new Book(3, "Book3", "Author3", 30);
            Book[] books = new Book[] { book3 };
            _events.AddBooksToCatalog(books, _library);

            // Act
            _events.RemoveBooksFromCatalog(books, _library);

            // Assert
            Assert.IsFalse(_library.GetCatalog().GetBooks().Contains(book3));
        }
    }
}