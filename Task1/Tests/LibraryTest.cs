using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Task1.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library _library;

        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        [Test]
        public void AddBook_Should_Add_Book_To_Catalog()
        {
            Book book = new Book("Book1");

            _library.AddBook(book);

            Assert.IsFalse(_library.Catalog.ContainsKey("Book1"));
        }




        [Test]
        public void AddUser_Should_Add_User()
        {
            User user = new User("White","John", 123, "JWhite@test.cs" );

            _library.AddUser(user);

            Assert.Contains(user, _library.GetUsers());
        }

        [Test]
        public void GetUser_Should_Return_User_With_Given_Name()
        {
            User user = new User("White","John", 123, "JWhite@test.cs" );
            _library.AddUser(user);

            User foundUser = _library.GetUser("John");

            Assert.AreEqual(user, foundUser);
        }

    }
}
