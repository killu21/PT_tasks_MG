// using NUnit.Framework;
// using Library;
// using System;
// using System.Collections.Generic;
// using Library.Data;
// using Library.Logic;
//
// namespace LibraryTests.LogicTests
// {
//     [TestFixture]
//     public class EventsTests
//     {
//         private IDataInterfaces.ICatalog _catalog;
//         private List<IDataInterfaces.IUser> _users;
//         private List<Rental> _rentals;
//         private State _state;
//         private Events _events;
//         private Library.Logic.Library _library;
//         private User _user;
//         private Book _book1;
//         private Book _book2;
//
//         [SetUp]
//         public void SetUp()
//         {
//             _catalog = new Inventory();
//             _users = new List<IDataInterfaces.IUser>();
//             _rentals = new List<Rental>();
//             _user = new Customer("Doe", "John", 1234567890, 100);
//             _book1 = new Book("Book1", "Author1", true);
//             _book2 = new Book("Book2", "Author2", true);
//             _library = new Library.Logic.Library(_catalog, _users, _rentals);
//             _state = new State(_library);
//             _events = new Events(_state);
//
//             // Add books to the library after creating the Library object
//             _library.AddBookToCatalog(_book1);
//             _library.AddBookToCatalog(_book2);
//         }
//
//         [Test]
//         public void AddBooksToCatalog_WithValidBooks_ShouldAddBooksToCatalog()
//         {
//             // Arrange
//             Book book3 = new Book("Book3", "Author3", false);
//             Book[] books = new Book[] { book3 };
//
//             // Act
//             _events.AddBooksToCatalog(books);
//
//             // Assert
//             Assert.IsTrue(_library.GetCatalog().GetBooks().Contains(book3));
//         }
//
//         [Test]
//         public void RemoveBooksFromCatalog_WithValidBooks_ShouldRemoveBooksFromCatalog()
//         {
//             // Arrange
//             Book book3 = new Book( "Book3", "Author3", true);
//             Book[] books = new Book[] { book3 };
//             _events.AddBooksToCatalog(books);
//  
//             // Act
//             _events.RemoveBooksFromCatalog(books);
//
//             // Assert
//             Assert.IsFalse(_library.GetCatalog().GetBooks().Contains(book3));
//         }
//         
//         [Test]
//         public void CheckOutBooks_WhenCalled_ShouldRentBooksToCustomer()
//         {
//             // Arrange
//             
//             Book book4 = new Book( "Book4", "Author4", true);
//             Book book5 = new Book( "Book5", "Author5", true);
//             _library.AddBookToCatalog(book4);
//             _library.AddBookToCatalog(book5);
//
//             _library.AddUser(_user);
//             DateTime dueDate = DateTime.Now.AddDays(30);
//              _state.SetCurrentLibrary(_library);
//             // Act
//             _events.CheckOutBooks((Customer)_user, dueDate, _library);
//
//             // Assert
//             Assert.Multiple(() =>
//             {
//                 Assert.IsTrue(book4.GetIsAvailable());
//                 Assert.IsTrue(book5.GetIsAvailable());
//                 Assert.IsFalse(_library.IsBookRented(book4));
//                 Assert.IsFalse(_library.IsBookRented(book5));
//             });
//         }
//     }
// }