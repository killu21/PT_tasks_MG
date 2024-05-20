using TestDataLayer.TestGenerators;
using DataLayer;

namespace TestDataLayer;

[TestFixture]
public class TestDataHardCoded
{
    private DataRepository _testRepo;
    private IData _data;
    
    [SetUp]
    public void Initialize()
    {
        IDataGenerator dataGenerator = new HardCodedDataGenerator();
        _testRepo = dataGenerator.GetTestRepo();
        _data = new DataLayer.Data(_testRepo);
    }

    [Test]
    public void TestGetBookId()
    {
        var bookId = _data.GetBookId(1);
        Assert.AreEqual(1, bookId);
    }

    [Test]
    public new void TestGetBookTitle()
    {
        var bookTitle = _data.GetBookTitle(1);
        Assert.AreEqual("Book 1", bookTitle);
    }

    [Test]
    public void TestGetBookAuthor()
    {
        var bookAuthor = _data.GetBookAuthor(1);
        Assert.AreEqual("Author 1", bookAuthor);
    }

    [Test]
    public void TestGetIsBookAvailable()
    {
        var isBookAvailable = _data.GetIsBookAvailable(1);
        Assert.IsTrue(isBookAvailable);
    }

    [Test]
    public void TestGetUserSurname()
    {
        var userSurname = _data.GetUserSurname(1);
        Assert.AreEqual("Smith", userSurname);
    }

    [Test]
    public void TestGetUserName()
    {
        var userName = _data.GetUserName(1);
        Assert.AreEqual("Alice", userName);
    }

    [Test]
    public void TestGetUserPhone()
    {
        var userPhone = _data.GetUserPhone(1);
        Assert.AreEqual(123456789, userPhone);
    }

    [Test]
    public void TestGetRentedBook()
    {
        var rentalId = _testRepo.RentalsList[0].RentalId;
        var rentedBook = _data.GetRentedBook(rentalId);
        Assert.IsNotNull(rentedBook);
    }

    [Test]
    public void TestGetRentedBy()
    {
        var rentalId = _testRepo.RentalsList[0].RentalId;
        var rentedBy = _data.GetRentedBy(rentalId);
        Assert.IsNotNull(rentedBy);
    }

    [Test]
    public void TestGetRentalDate()
    {
        var rentalId = _testRepo.RentalsList[0].RentalId;
        var rentalDate = _data.GetRentalDate(rentalId);
        Assert.IsNotNull(rentalDate);
    }

    [Test]
    public void TestGetDueDate()
    {
        var rentalId = _testRepo.RentalsList[0].RentalId;
        var dueDate = _data.GetDueDate(rentalId);
        Assert.IsNotNull(dueDate);
    }

    [Test]
    public void TestIsOverdue()
    {
        var rentalId = _testRepo.RentalsList[0].RentalId;
        var isOverdue = _data.IsOverdue(rentalId);
        Assert.IsFalse(isOverdue);
    }

    [Test]
    public void TestRentalToString()
    {
        var rentalId = _testRepo.RentalsList[0].RentalId;
        var rentalString = _data.RentalToString(rentalId);
        Assert.IsNotNull(rentalString);
    }
}