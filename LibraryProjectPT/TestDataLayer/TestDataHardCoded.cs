using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataLayer.TestGenerators;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestDataLayer;

[TestClass]
public class TestDataHardCoded : TestData
{
    [TestInitialize]
    public override void Initialize()
    {
        IDataGenerator dataGenerator = new HardCodedDataGenerator();
        TestRepo = dataGenerator.GetTestRepo();
        Data = new DataLayer.Data(TestRepo);
    }

    [TestMethod]
    public new void TestGetBookId()
    {
        var bookId = Data.GetBookId(1);
        Assert.AreEqual(1, bookId);
    }

    [TestMethod]
    public new void TestGetBookTitle()
    {
        var bookTitle = Data.GetBookTitle(1);
        Assert.AreEqual("Book 1", bookTitle);
    }

    [TestMethod]
    public void TestGetBookAuthor()
    {
        var bookAuthor = Data.GetBookAuthor(1);
        Assert.AreEqual("Author 1", bookAuthor);
    }

    [TestMethod]
    public void TestGetIsBookAvailable()
    {
        var isBookAvailable = Data.GetIsBookAvailable(1);
        Assert.IsTrue(isBookAvailable);
    }

    [TestMethod]
    public void TestGetUserSurname()
    {
        var userSurname = Data.GetUserSurname(1);
        Assert.AreEqual("Smith", userSurname);
    }

    [TestMethod]
    public void TestGetUserName()
    {
        var userName = Data.GetUserName(1);
        Assert.AreEqual("Alice", userName);
    }

    [TestMethod]
    public void TestGetUserPhone()
    {
        var userPhone = Data.GetUserPhone(1);
        Assert.AreEqual(123456789, userPhone);
    }

    [TestMethod]
    public void TestGetRentedBook()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentedBook = Data.GetRentedBook(rentalId);
        Assert.IsNotNull(rentedBook);
    }

    [TestMethod]
    public void TestGetRentedBy()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentedBy = Data.GetRentedBy(rentalId);
        Assert.IsNotNull(rentedBy);
    }

    [TestMethod]
    public void TestGetRentalDate()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentalDate = Data.GetRentalDate(rentalId);
        Assert.IsNotNull(rentalDate);
    }

    [TestMethod]
    public void TestGetDueDate()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var dueDate = Data.GetDueDate(rentalId);
        Assert.IsNotNull(dueDate);
    }

    [TestMethod]
    public void TestIsOverdue()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var isOverdue = Data.IsOverdue(rentalId);
        Assert.IsFalse(isOverdue);
    }

    [TestMethod]
    public void TestRentalToString()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentalString = Data.RentalToString(rentalId);
        Assert.IsNotNull(rentalString);
    }
}