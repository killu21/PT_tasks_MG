using System;

namespace Library;

class Program
{
    public static void Main(string[] args)
    {
        // Create a library
        Library library = new Library();

        // Create some users
        Staff staff1 = new Staff("John", "Doe", 1234, 3000);
        Customer customer1 = new Customer("Alice", "Smith", 5678, 100, 200);
        // Add users to the library
        library.AddUser(staff1);
        library.AddUser(customer1);
        
        // Create some books
        Book book1 = new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", 40);
        Book book2 = new Book(2, "To Kill a Mockingbird", "Harper Lee", 60);

        // Add books to the library catalog
        library.AddBook(book1);
        library.AddBook(book2);

        // Rent a book
        DateTime rentalDate = DateTime.Now;
        DateTime dueDate = rentalDate.AddDays(14); // Due date is 14 days from now
        library.RentBook(book1, customer1, rentalDate, dueDate);

        // Check if a book is rented
        Console.WriteLine($"Is '{book1.GetTitle()}' rented? {library.IsBookRented(book1)}");

        // Return a book
        library.ReturnBook(book1);

        // Check if a book is rented after returning
        Console.WriteLine($"Is '{book1.GetTitle()}' rented? {library.IsBookRented(book1)}");

        // Print library information
        Console.WriteLine("\nLibrary Information:");
        Console.WriteLine($"Catalog:");
        foreach (Book book in library.GetCatalog().GetBooks())
        {
            Console.WriteLine($"- {book.GetTitle()} by {book.GetAuthor()}");
        }
        Console.WriteLine($"Users:");
        foreach (User user in library.GetUsers())
        {
            Console.WriteLine($"- {user.GetName()}");
        }
    }
}