using Data;
using Data.Inventory;
using Data.State;
using Data.Users;

namespace DataTest.TestGenerators
{
    internal class FixedDataGenerator : IDataGenerator
    {
        private DataRepository _context;

        public FixedDataGenerator()
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

        private void GenerateUsers()
        {
            List<User> users = new()
            {
                new Customer(1, "Alice", "Smith", 123456789),
                new Customer(2, "Bob", "Johnson", 345678901),
                new Customer(3, "Charlie", "Brown", 567890123),
                new Staff(1001, "David", "Miller", 678901234),
                new Staff(1002, "Eva", "Green", 789012345),
                new Staff(1003, "Frank", "Sinatra", 890123456), 
            };

            foreach (User user in users)
            {
                _context.UsersList.Add(user);
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
                _context.BooksCatalog.AddBookToCatalog(book);
            }
        }

        private void GenerateRentals()
        {
            List<Rental> rentals = new()
            {
                new Rental(Guid.NewGuid(), _context.BooksCatalog.GetBookFromCatalog(1), _context.UsersList[0] as Customer ?? throw new InvalidOperationException(), DateTime.Now, DateTime.Now.AddDays(7)),
                new Rental(Guid.NewGuid(), _context.BooksCatalog.GetBookFromCatalog(2), _context.UsersList[1] as Customer ?? throw new InvalidOperationException(), DateTime.Now, DateTime.Now.AddDays(4)),
                new Rental(Guid.NewGuid(), _context.BooksCatalog.GetBookFromCatalog(3), _context.UsersList[2] as Customer ?? throw new InvalidOperationException(), DateTime.Now, DateTime.Now.AddDays(6)), 
                new Rental(Guid.NewGuid(), _context.BooksCatalog.GetBookFromCatalog(4), _context.UsersList[3] as Customer ?? throw new InvalidOperationException(), DateTime.Now, DateTime.Now.AddDays(2)),
            };

            foreach (Rental rental in rentals)
            {
                _context.RentalsList.Add(rental);
            }
        }
    }
}