using Data;
using Data.Inventory;
using Data.State;
using Data.Users;

namespace DataTest.TestGenerators;

internal class RandomDataGenerator : IDataGenerator
{
    private readonly Random random = new(DateTime.Now.Millisecond);

    private DataRepository _context;

    public RandomDataGenerator()
    {
        _context = new DataRepository();

        GenerateUsers();
        GenerateBooks();
        GenerateRentals();
    }

    

    public DataRepository GetDataContext()
    {
        return _context;
    }

    
    private void GenerateBooks()
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

        for (int i = 0; i < 10; i++)
        {
            Book book = new Book(i + 1, titles[random.Next(titles.Length)], authors[random.Next(authors.Length)], true);
            _context.BooksCatalog.AddBookToCatalog(book);
        }
    }
    
    private void GenerateUsers()
    {
        string[] firstNames = { "John", "Emma", "Michael", "Sophia", "William", "Olivia", "James", "Ava", "Alexander", "Isabella" };
        string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
        string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "icloud.com" };

        for (int i = 0; i < 10; i++)
        {
            Customer customer = new Customer(i + 1, lastNames[random.Next(lastNames.Length)],
                firstNames[random.Next(firstNames.Length)], GenerateRandomPhoneNumber());
            
            _context.UsersList.Add(customer);

            Staff staff = new Staff(i + 1001, lastNames[random.Next(lastNames.Length)], firstNames[random.Next(firstNames.Length)], GenerateRandomPhoneNumber());
            _context.UsersList.Add(staff);
        }
    }

    
    private static long GenerateRandomPhoneNumber()
    {
        Random random = new Random();
        long phoneNumber = 0;
        for (int i = 0; i < 10; i++)
        {
            phoneNumber += random.Next(0, 10);
        }
        return phoneNumber;
    }
    private void GenerateRentals()
    {
        for (int i = 0; i < 10; i++)
        {
            Customer customer = _context.UsersList.OfType<Customer>().ElementAt(random.Next(_context.UsersList.OfType<Customer>().Count()));
            Book book = _context.BooksCatalog.books.Values.ElementAt(random.Next(_context.BooksCatalog.books.Count));

            if (book.IsAvailable)
            {
                Rental rental = new Rental(Guid.NewGuid(), book, customer, DateTime.Now, DateTime.Now.AddDays(random.Next(1, 30)));
                _context.RentalsList.Add(rental);

                book.IsAvailable = false;
            }
        }
    }
}


