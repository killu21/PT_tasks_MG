using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace LibraryTests.LogicTests
{
    [TestFixture]
    public class EventsTests
    {
        private State _state;
        private Events _events;
        private Library.Library _library;
        private User _user;
        private Book _book1;
        private Book _book2;

        [SetUp]
        public void SetUp()
        {
            _user = new Customer("Doe", "John", 1234567890, 100);
            _book1 = new Book("Book1", "Author1", true);
            _book2 = new Book("Book2", "Author2", true);
            _library = new Library.Library();
            _state = new State(_library);
            _events = new Events(_state);

            // Add books to the library after creating the Library object
            _library.AddBookToCatalog(_book1);
            _library.AddBookToCatalog(_book2);
        }

        [Test]
        public void AddBooksToCatalog_WithValidBooks_ShouldAddBooksToCatalog()
        {
            // Arrange
            Book book3 = new Book("Book3", "Author3", false);
            Book[] books = new Book[] { book3 };

            // Act
            _events.AddBooksToCatalog(books);

            // Assert
            Assert.IsTrue(_library.GetCatalog().GetBooks().Contains(book3));
        }

        [Test]
        public void RemoveBooksFromCatalog_WithValidBooks_ShouldRemoveBooksFromCatalog()
        {
            // Arrange
            Book book3 = new Book( "Book3", "Author3", true);
            Book[] books = new Book[] { book3 };
            _events.AddBooksToCatalog(books);
 
            // Act
            _events.RemoveBooksFromCatalog(books);

            // Assert
            Assert.IsFalse(_library.GetCatalog().GetBooks().Contains(book3));
        }
    }
}