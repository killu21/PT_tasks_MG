namespace Data.Inventory;
public class Book
{
    private readonly int _bookId;
    private readonly string _title;
    private readonly string _author;
    private bool _isAvailable;

    protected Book(int bookId, string title, string author, bool isAvailable)
    {
        _bookId = bookId;
        _title = title;
        _author = author;
        _isAvailable = isAvailable;
    }
    
    public int GetId() { return _bookId; }
    
    public  string GetTitle() { return _title; }
    
    public  string GetAuthor() { return _author; }
    
    public  bool GetIsAvailable() { return _isAvailable; }
    
    public void SetIsAvailable(bool value) { _isAvailable = value; }
}