using NUnit.Framework;
using System;
using System.Linq;
using Task1;

namespace Task1.Tests
{
    public class LibraryServiceTests
    {
        private LibraryService _libraryService;

        [SetUp]
        public void Setup()
        {
            _libraryService = new LibraryService(new DataContext());
        }

        [Test]
        public void AddUser_Should_Add_User_To_Library()
        {
            string surname = "Doe";
            string name = "John";
            int phone = 123456789;
            string email = "john@example.com";

            _libraryService.AddUser(surname, name, phone, email);

            Assert.AreEqual(1, _libraryService.GetLibrary().GetUsers().Count);
            var user = _libraryService.GetLibrary().GetUsers().FirstOrDefault();
            Assert.IsNotNull(user);
            Assert.AreEqual(surname, user.GetSurname());
            Assert.AreEqual(name, user.GetName());
            Assert.AreEqual(phone, user.GetPhone());
            Assert.AreEqual(email, user.GetEmail());
        }

        [Test]
        public void CheckoutBook_Should_Checkout_Book()
        {
            string userName = "John Doe";
            string bookName = "Book1";
            _libraryService.AddUser("Doe", "John", 123456789, "john@example.com");
            _libraryService.AddBookToCatalog(1, new Book(bookName));

            _libraryService.CheckoutBook(userName, bookName);

            var rentals = _libraryService.GetRentals();
            Assert.AreEqual(0, rentals.Count);
        }


        [Test]
        public void ReturnBook_Should_Return_Book()
        {
            string userName = "John Doe";
            string bookName = "Book1";
            _libraryService.AddUser("Doe", "John", 123456789, "john@example.com");
            _libraryService.AddBookToCatalog(1, new Book(bookName));
            _libraryService.CheckoutBook(userName, bookName);

            _libraryService.ReturnBook(userName, bookName);

            var rentals = _libraryService.GetRentals();
            Assert.AreEqual(0, rentals.Count);
            var user = _libraryService.GetUser(userName);
            Assert.IsNull(user);
            Assert.IsFalse(_libraryService.GetLibrary().Catalog.ContainsKey(bookName));
        }

    }
}
