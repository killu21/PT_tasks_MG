using NUnit.Framework;
using System;

namespace Task1.Tests
{
    [TestFixture]
    public class RentalTests
    {
        [Test]
        public void Rental_Constructor_Should_Set_Properties()
        {
            
            User user = new User("John", "Doe", 123456789, "john@example.com");
            Book book = new Book("Book1");
            DateTime rentalDate = DateTime.Now;

            Rental rental = new Rental(user, book, rentalDate);

            Assert.AreEqual(user, rental.User);
            Assert.AreEqual(book, rental.Book);
            Assert.AreEqual(rentalDate, rental.RentalDate);
        }
    }
}