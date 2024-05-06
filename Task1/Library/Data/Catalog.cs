namespace Library.Data;
public class Catalog : IDataInterfaces.ICatalog
{
    private readonly Dictionary<int, IDataInterfaces.IBook> _books;

    public Catalog(Dictionary<int, IDataInterfaces.IBook> initialBooks = null)
    {
        _books = initialBooks ?? new Dictionary<int, IDataInterfaces.IBook>();
    }

    public void AddBook(IDataInterfaces.IBook book)
    {
        _books.Add(book.GetId(), book);
    }

    public void RemoveBook(IDataInterfaces.IBook book)
    {
        _books.Remove(book.GetId());
    }

    public List<IDataInterfaces.IBook> GetBooks()
    {
        return new List<IDataInterfaces.IBook>(_books.Values);
    }
}