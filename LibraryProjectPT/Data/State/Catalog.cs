using Data.Inventory;

namespace Data.State;
public class Catalog(Dictionary<int, Book> books)
{
    public void AddBook(Book book)
    {
        books.Add(book.GetId(), book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book.GetId());
    }

    public List<Book> GetBooks()
    {
        return new List<Book>(books.Values);
    }
}