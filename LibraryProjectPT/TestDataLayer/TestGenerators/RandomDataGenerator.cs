using DataLayer;
using DataLayer.Inventory;
using DataLayer.State;
using DataLayer.Users;

namespace TestDataLayer.TestGenerators;

public class RandomDataGenerator : IDataGenerator
{
    private readonly Random _random = new(DateTime.Now.Millisecond);
    private readonly DataRepository _randomTestRepo;

    public RandomDataGenerator()
    {
        _randomTestRepo = new DataRepository();

        GenerateUsers();
        GenerateBooks();
        GenerateRentals();
    }
    
    public DataRepository GetTestRepo()
    {
        return _randomTestRepo;
    }
    
    private void GenerateBooks()    // Generate 10 available books
    {
        string[] titles = {
            "The Great Gatsby",
            "To Kill a Mockingbird",
            "1984",
            "Pride and Prejudice",
            "The Catcher in the Rye",
            "The Lord of the Rings",
            "The Hobbit",
            "Moby Dick",
            "War and Peace",
            "Anna Karenina"
        };

        string[] authors = {
            "F. Scott Fitzgerald",
            "Harper Lee",
            "George Orwell",
            "Jane Austen",
            "J.D. Salinger",
            "J.R.R. Tolkien",
            "Herman Melville",
            "Leo Tolstoy",
            "Charles Dickens",
            "Ernest Hemingway"
        };

        for (var i = 0; i < 10; i++)
        {
            var book = new Book(i + 1, titles[_random.Next(titles.Length)], authors[_random.Next(authors.Length)], true);
            _randomTestRepo.BooksCatalog.AddBookToCatalog(book);
        }
    }
    
    private void GenerateUsers()
    {
        string[] firstNames = { "John", "Emma", "Michael", "Sophia", "William", "Olivia", "James", "Ava", "Alexander", "Isabella" };
        string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };

        for (var i = 0; i < 10; i++)
        {
            var customer = new Customer(i + 1, lastNames[_random.Next(lastNames.Length)],
                firstNames[_random.Next(firstNames.Length)], GenerateRandomPhoneNumber());
            
            _randomTestRepo.UsersList.Add(customer);

            var staff = new Staff(i + 1001, lastNames[_random.Next(lastNames.Length)], firstNames[_random.Next(firstNames.Length)], GenerateRandomPhoneNumber());
            _randomTestRepo.UsersList.Add(staff);
        }
    }
    
    private static int GenerateRandomPhoneNumber()
    {
        var random = new Random();
        var phoneNumber = 0;
        for (var i = 0; i < 9; i++)
        {
            // Ensure the first digit is not 0
            var digit = i == 0 ? random.Next(1, 10) : random.Next(0, 10);
            phoneNumber = phoneNumber * 10 + digit;
        }
        return phoneNumber;
    }
    
    // Generating 10 rentals assuming that there are 10 available books.
    // Always assigns books in the same order but to random customers
    private void GenerateRentals()
    {
        for (var i = 0; i < 10; i++)
        {
            var customer = _randomTestRepo.UsersList.OfType<Customer>().ElementAt(_random.Next(_randomTestRepo.UsersList.OfType<Customer>().Count()));
            var book = _randomTestRepo.BooksCatalog.books.Values.ElementAt(i);

            if (!book.IsAvailable) continue;
            var rental = new Rental(Guid.NewGuid(), book, customer, DateTime.Now, DateTime.Now.AddDays(_random.Next(1, 30)));
            _randomTestRepo.RentalsList.Add(rental);

            book.IsAvailable = false;
        }
    }
}