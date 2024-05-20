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
        int bookId = 1;
        int customerId = 1;
        var dueDate = DateTime.Now.AddDays(7);
        
       
        _library.RentBook(bookId, customerId, dueDate);
        
        var rentedBook = _data.GetBookFromCatalog(bookId);
        Assert.IsFalse(rentedBook.IsAvailable);
    }
}