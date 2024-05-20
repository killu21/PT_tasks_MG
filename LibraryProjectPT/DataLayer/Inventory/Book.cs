namespace DataLayer.Inventory;
public class Book
{
    public int BookId { get; }
    public string Title { get; }
    public string Author { get; }
    public bool IsAvailable { get; set; }

    public Book(int bookId, string title, string author, bool isAvailable)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        IsAvailable = isAvailable;
    }
}