using DataLayer;
using Logic;
using TestDataLayer;
using TestDataLayer.TestGenerators;

namespace TestLogicLayer;

[TestFixture]
public class TestLogicHardCoded
{
    private Library _library;
    private DataRepository _dataRepository;
    private IData _data;
    
    [SetUp]
    public void SetUp()
    {   // I'm sure we can do it somehow better
        IDataGenerator dataGenerator = new LogicDataGenerator();
        _dataRepository = dataGenerator.GetTestRepo();
        _data = new DataLayer.Data(_dataRepository);
        _library = new Library(_data);
    }
    [Test]
    public void RentBook_WhenBookIsAvailable_ShouldRentBook()
    {
        const int bookId = 1;
        const int customerId = 1;
        var dueDate = DateTime.Now.AddDays(7);
        
       
        _library.RentBook(bookId, customerId, dueDate);
        
        var rentedBook = _data.GetBookFromCatalog(bookId);
        Assert.IsFalse(rentedBook.IsAvailable);
    }
    
    [Test]
    public void ReturnBook_WhenBookIsRented_ShouldReturnBook()
    {
        const int bookId = 1;
        const int customerId = 1;
        _library.RentBook(bookId, customerId, DateTime.Now.AddDays(7));
        
        _library.ReturnBook(bookId);
        
        var returnedBook = _data.GetBookFromCatalog(bookId);
        Assert.IsTrue(returnedBook.IsAvailable);
    }
}