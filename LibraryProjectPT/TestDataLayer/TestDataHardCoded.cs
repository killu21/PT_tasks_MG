using TestDataLayer.TestGenerators;

namespace TestDataLayer;

[TestFixture]
public class TestDataHardCoded : TestData
{
    [SetUp]
    public override void Initialize()
    {
        IDataGenerator dataGenerator = new HardCodedDataGenerator();
        TestRepo = dataGenerator.GetTestRepo();
        Data = new DataLayer.Data(TestRepo);
    }

    [Test]
    public new void TestGetBookId()
    {
        var bookId = Data.GetBookId(1);
        Assert.AreEqual(1, bookId);
    }

    [Test]
    public new void TestGetBookTitle()
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