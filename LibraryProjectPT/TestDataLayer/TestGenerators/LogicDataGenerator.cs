using DataLayer;
using DataLayer.Inventory;
using DataLayer.Users;

namespace TestDataLayer.TestGenerators;

public class LogicDataGenerator : IDataGenerator
{
    private readonly DataRepository _hardCodedTestRepo;

    public LogicDataGenerator()
    {
        _hardCodedTestRepo = new DataRepository();

        GenerateUsers();
        GenerateBooks();
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
}