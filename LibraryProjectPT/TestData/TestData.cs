using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Data.Users;
using DataTest;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DataTest
{
    [TestClass]
    public abstract class TestData
    {
        private DataRepository _context;
        private IData _data;
        public abstract void Initialize();
       

        [TestMethod]
        public void TestGenerateUsers()
        {
            Assert.AreEqual(6, _context.UsersList.Count);
            Assert.AreEqual(3, _context.UsersList.OfType<Customer>().Count());
            Assert.AreEqual(3, _context.UsersList.OfType<Staff>().Count());
        }

        [TestMethod]
        public void TestGenerateBooks()
        {
            Assert.AreEqual(5, _context.BooksCatalog.books.Count);
            Assert.IsTrue(_context.BooksCatalog.books.Values.All(book => book.IsAvailable));
        }

        [TestMethod]
        public void TestGenerateRentals()
        {
            Assert.AreEqual(4, _context.RentalsList.Count);
            Assert.IsTrue(_context.RentalsList.All(rental => true));
        }
        [TestMethod]
        public void TestGetBookId()
        {
            var bookId = _data.GetBookId(1);
            Assert.AreEqual(1, bookId);
        }

        [TestMethod]
        public void TestGetBookTitle()
        {
            var bookTitle = _data.GetBookTitle(1);
            Assert.AreEqual("Book 1", bookTitle);
        }

        [TestMethod]
        public void TestGetBookAuthor()
        {
            var bookAuthor = _data.GetBookAuthor(1);
            Assert.AreEqual("Author 1", bookAuthor);
        }

        [TestMethod]
        public void TestGetIsBookAvailable()
        {
            var isBookAvailable = _data.GetIsBookAvailable(1);
            Assert.IsTrue(isBookAvailable);
        }

        [TestMethod]
        public void TestGetUserSurname()
        {
            var userSurname = _data.GetUserSurname(1);
            Assert.AreEqual("Smith", userSurname);
        }

        [TestMethod]
        public void TestGetUserName()
        {
            var userName = _data.GetUserName(1);
            Assert.AreEqual("Alice", userName);
        }

        [TestMethod]
        public void TestGetUserPhone()
        {
            var userPhone = _data.GetUserPhone(1);
            Assert.AreEqual(123456789, userPhone);
        }
        

        [TestMethod]
        public void TestGetRentedBook()
        {
            var rentalId = _context.RentalsList[0].RentalId;
            var rentedBook = _data.GetRentedBook(rentalId);
            Assert.IsNotNull(rentedBook);
        }

        [TestMethod]
        public void TestGetRentedBy()
        {
            var rentalId = _context.RentalsList[0].RentalId;
            var rentedBy = _data.GetRentedBy(rentalId);
            Assert.IsNotNull(rentedBy);
        }

        [TestMethod]
        public void TestGetRentalDate()
        {
            var rentalId = _context.RentalsList[0].RentalId;
            var rentalDate = _data.GetRentalDate(rentalId);
            Assert.IsNotNull(rentalDate);
        }

        [TestMethod]
        public void TestGetDueDate()
        {
            var rentalId = _context.RentalsList[0].RentalId;
            var dueDate = _data.GetDueDate(rentalId);
            Assert.IsNotNull(dueDate);
        }

        [TestMethod]
        public void TestIsOverdue()
        {
            var rentalId = _context.RentalsList[0].RentalId;
            var isOverdue = _data.IsOverdue(rentalId);
            Assert.IsFalse(isOverdue);
        }

        [TestMethod]
        public void TestRentalToString()
        {
            var rentalId = _context.RentalsList[0].RentalId;
            var rentalString = _data.RentalToString(rentalId);
            Assert.IsNotNull(rentalString);
        }
    }
}