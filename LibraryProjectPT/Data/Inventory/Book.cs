namespace Data.Inventory;
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

    // public int GetBookId();
    // public string GetTitle();
    // public string GetAuthor();
    // public bool GetIsAvailable();
    // public void SetBookId(int value);
    // public void SetTitle(string value);
    // public void SetAuthor(string value);
    // public void SetIsAvailable(bool value);
}