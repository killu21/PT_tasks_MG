using DataLayer;
using DataLayer.Inventory;
using DataLayer.State;
using DataLayer.Users;

namespace TestDataLayer.TestGenerators;

internal class HardCodedDataGenerator : IDataGenerator
{
    private readonly DataRepository _hardCodedTestRepo;

    public HardCodedDataGenerator()
    {
        _hardCodedTestRepo = new DataRepository();

        GenerateUsers();
        GenerateBooks();
        GenerateRentals();
    }

    public DataRepository GetTestRepo()
    {
        return _hardCodedTestRepo;
    }

    private void GenerateUsers()
    {
        List<User> users = new()
        {
            new Customer(1, "Smith", "Alice", 123456789),
            new Customer(2, "Johnson", "Bob", 345678901),
            new Customer(3, "Brown", "Charlie", 567890123),
            new Staff(1001, "Miller", "David", 678901234),
            new Staff(1002, "Green", "Eva", 789012345),
            new Staff(1003, "Sinatra", "Frank", 890123456), 
        };

        foreach (User user in users)
        {
            _hardCodedTestRepo.UsersList.Add(user);
        }
    }

    private void GenerateBooks()
    {
        List<Book> books = new()
        {
            new Book(1, "Book 1", "Author 1", true),
            new Book(2, "Book 2", "Author 2", true),
            new Book(3, "Book 3", "Author 3", true), 
            new Book(4, "Book 4", "Author 4", true), 
            new Book(5, "Book 5", "Author 5", true), 
        };

        foreach (Book book in books)
        {
            _hardCodedTestRepo.BooksCatalog.AddBookToCatalog(book);
        }
    }

    private void GenerateRentals()
    {
        List<Rental> rentals = new()
        {
            new Rental(Guid.NewGuid(), _hardCodedTestRepo.BooksCatalog.GetBookFromCatalog(1), _hardCodedTestRepo.UsersList[0] as Customer ?? throw new InvalidOperationException(), DateTime.Now, DateTime.Now.AddDays(7)),
            new Rental(Guid.NewGuid(), _hardCodedTestRepo.BooksCatalog.GetBookFromCatalog(2), _hardCodedTestRepo.UsersList[1] as Customer ?? throw new InvalidOperationException(), DateTime.Now, DateTime.Now.AddDays(4)),
            new Rental(Guid.NewGuid(), _hardCodedTestRepo.BooksCatalog.GetBookFromCatalog(3), _hardCodedTestRepo.UsersList[2] as Customer ?? throw new InvalidOperationException(), DateTime.Now, DateTime.Now.AddDays(6)), 
        };

        foreach (Rental rental in rentals)
        {
            _hardCodedTestRepo.RentalsList.Add(rental);
        }
    }
}