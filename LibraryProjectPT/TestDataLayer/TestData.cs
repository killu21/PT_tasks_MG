using DataLayer;
using DataLayer.Users;

namespace TestDataLayer;

[TestFixture]
public abstract class TestData
{
    protected DataRepository TestRepo;
    protected IData Data;
    public abstract void Initialize();

    [Test]
    public void TestGenerateUsers()
    {
        Assert.AreEqual(6, TestRepo.UsersList.Count);
        Assert.AreEqual(3, TestRepo.UsersList.OfType<Customer>().Count());
        Assert.AreEqual(3, TestRepo.UsersList.OfType<Staff>().Count());
    }

    [Test]
    public void TestGenerateBooks()
    {
        Assert.AreEqual(5, TestRepo.BooksCatalog.books.Count);
        Assert.IsTrue(TestRepo.BooksCatalog.books.Values.All(book => book.IsAvailable));
    }

    [Test]
    public void TestGenerateRentals()
    {
        Assert.AreEqual(4, TestRepo.RentalsList.Count);
        Assert.IsTrue(TestRepo.RentalsList.All(rental => true));
    }
    [Test]
    public void TestGetBookId()
    {
        var bookId = Data.GetBookId(1);
        Assert.AreEqual(1, bookId);
    }

    [Test]
    public void TestGetBookTitle()
    {
        var bookTitle = Data.GetBookTitle(1);
        Assert.AreEqual("Book 1", bookTitle);
    }

    [Test]
    public void TestGetBookAuthor()
    {
        var bookAuthor = Data.GetBookAuthor(1);
        Assert.AreEqual("Author 1", bookAuthor);
    }

    [Test]
    public void TestGetIsBookAvailable()
    {
        var isBookAvailable = Data.GetIsBookAvailable(1);
        Assert.IsTrue(isBookAvailable);
    }

    [Test]
    public void TestGetUserSurname()
    {
        var userSurname = Data.GetUserSurname(1);
        Assert.AreEqual("Smith", userSurname);
    }

    [Test]
    public void TestGetUserName()
    {
        var userName = Data.GetUserName(1);
        Assert.AreEqual("Alice", userName);
    }

    [Test]
    public void TestGetUserPhone()
    {
        var userPhone = Data.GetUserPhone(1);
        Assert.AreEqual(123456789, userPhone);
    }
        

    [Test]
    public void TestGetRentedBook()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentedBook = Data.GetRentedBook(rentalId);
        Assert.IsNotNull(rentedBook);
    }

    [Test]
    public void TestGetRentedBy()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentedBy = Data.GetRentedBy(rentalId);
        Assert.IsNotNull(rentedBy);
    }

    [Test]
    public void TestGetRentalDate()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentalDate = Data.GetRentalDate(rentalId);
        Assert.IsNotNull(rentalDate);
    }

    [Test]
    public void TestGetDueDate()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var dueDate = Data.GetDueDate(rentalId);
        Assert.IsNotNull(dueDate);
    }

    [Test]
    public void TestIsOverdue()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var isOverdue = Data.IsOverdue(rentalId);
        Assert.IsFalse(isOverdue);
    }

    [Test]
    public void TestRentalToString()
    {
        var rentalId = TestRepo.RentalsList[0].RentalId;
        var rentalString = Data.RentalToString(rentalId);
        Assert.IsNotNull(rentalString);
    }
}