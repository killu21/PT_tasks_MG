using TestDataLayer.TestGenerators;
using DataLayer;

namespace TestDataLayer;

[TestFixture]
public class TestDataRandom 
{
    private DataRepository _testRepo;
    private IData _data;
    
    [SetUp]
    public void Initialize()
    {
        IDataGenerator dataGenerator = new RandomDataGenerator();
        _testRepo = dataGenerator.GetTestRepo();
        _data = new DataLayer.Data(_testRepo);
    }
    
    [Test]
    public void TestGetBookId()
    {
        var bookId = _data.GetBookId(1);
        Assert.AreEqual(_testRepo.BooksCatalog.GetBookFromCatalog(1).BookId, bookId);
    }

    [Test]
    public void TestGetBookTitle()
    {
        var bookTitle = _data.GetBookTitle(1);
        Assert.AreEqual(_testRepo.BooksCatalog.GetBookFromCatalog(1).Title, bookTitle);
    }

    [Test]
    public void TestGetBookAuthor()
    {
        var bookAuthor = _data.GetBookAuthor(1);
        Assert.AreEqual(_testRepo.BooksCatalog.GetBookFromCatalog(1).Author, bookAuthor);
    }

    [Test]
    public void TestGetIsBookAvailable()
    {
        var isBookAvailable = _data.GetIsBookAvailable(1);
        Assert.IsFalse(isBookAvailable);
    }

    [Test]
    public void TestGetUserSurname()
    {
        var userSurname = _data.GetUserSurname(1);
        Assert.AreEqual(_testRepo.UsersList[0].Surname, userSurname);
    }

    [Test]
    public void TestGetUserName()
    {
        var userName = _data.GetUserName(2);
        Assert.AreEqual(_testRepo.UsersList[2].Name, userName);
    }

    [Test]
    public void TestGetUserPhone()
    {
        var userPhone = _data.GetUserPhone(1);
        Assert.AreEqual(_testRepo.UsersList[0].Phone, userPhone);
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