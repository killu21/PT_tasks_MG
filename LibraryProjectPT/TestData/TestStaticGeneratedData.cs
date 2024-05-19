using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using DataTest.TestGenerators;
using Data.Users;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DataTest
{
    [TestClass]
    public class TestStaticGeneratedData : TestData
    {
        [TestInitialize]
        public override void Initialize()
        {
            IDataGenerator dataGenerator = new StaticDataGenerator();
            _context = dataGenerator.GetDataContext();
            _data = new Data.Data(_context);
        }

        [TestMethod]
        public new void TestGetBookId()
        {
            var bookId = _data.GetBookId(1);
            Assert.AreEqual(1, bookId);
        }

        [TestMethod]
        public new void TestGetBookTitle()
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