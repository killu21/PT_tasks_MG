using Data.Inventory;

namespace Data.State;
public class Catalog
{
    public Dictionary<int, Book> books;

    public Catalog()
    {
        books = new Dictionary<int, Book>();
    }

    public void AddBookToCatalog(Book book)
    {
        books.Add(book.BookId, book);
    }

    public void RemoveBookFromCatalog(Book book)
    {
        books.Remove(book.BookId);
    }
    
    public Book GetBookFromCatalog(int bookId)
    {
        if (books.TryGetValue(bookId, out var book))
        {
            return book;
        }
        
        throw new KeyNotFoundException("The provided key was not found in the BooksDictionary.");
    }
}