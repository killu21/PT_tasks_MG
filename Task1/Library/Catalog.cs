using System.Collections.Generic;

namespace Library;

public class Catalog
{
    private Dictionary<int, Book> _books;

    public Catalog(Dictionary<int, Book> initialBooks = null)
    {
        _books = initialBooks ?? new Dictionary<int, Book>();
    }

    public void AddBook(Book book)
    {
        _books.Add(book.GetId(), book);
    }

    public void RemoveBook(Book book)
    {
        _books.Remove(book.GetId());
    }

    public List<Book> GetBooks()
    {
        return new List<Book>(_books.Values);
    }
}