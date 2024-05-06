namespace Library;

public class Events
{
    private readonly List<Book> _books;
    
    public Events(State state)
    {
       _books = state.GetCurrentCatalog().GetBooks();
    }

    public void CheckOutBooks(Customer customer, DateTime dueDate, Library library)
    {
        foreach (var book in _books)
        {
            if (!library.GetCatalog().GetBooks().Contains(book))
            {
                throw new InvalidOperationException($"Book '{book.GetTitle()}' is not available in the library.");
            }
        }

        if (!library.GetUsers().Contains(customer))
        {
            throw new InvalidOperationException($"User '{customer.GetName()}' is not registered with the library.");
        }

        foreach (var book in _books)
        {
            if (library.IsBookRented(book))
            {
                throw new InvalidOperationException($"Book '{book.GetTitle()}' is already rented.");
            }
        }

        // Rent the books
        foreach (var book in _books)
        {
            library.RentBook(book, customer, dueDate);
        }
    }

    public void ReturnBooks(Library library)
    {
        // Return the books
        foreach (var book in _books)
        {
            library.ReturnBook(book);
        }
    }

    public void AddBooksToCatalog(Library library)
    {
        foreach (var book in _books)
        {
            library.AddBookToCatalog(book);
        }
    }

    public void RemoveBooksFromCatalog(Library library)
    {
        foreach (var book in _books)
        {
            library.DeleteBookFromCatalog(book);
        }
    }
}