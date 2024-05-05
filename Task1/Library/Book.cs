namespace Library;

public class Book
{
    private static int _nextBookId = 1;
    private readonly int _bookId;
    private readonly string _title;
    private readonly string _author;
    private bool _isAvailable;

    public Book(string title, string author, bool isAvailable)
    {
        _bookId = _nextBookId;
        _title = title;
        _author = author;
        _isAvailable = isAvailable;
        _nextBookId++;
    }
    
    public static int GetNextBookId() { return _nextBookId; }
    
    public int GetId() { return _bookId; }

    public string GetTitle() { return _title; }

    public string GetAuthor() { return _author; }
    
    public bool GetIsAvailable() { return _isAvailable; }
    
    public void SetIsAvailable(bool value) { _isAvailable = value; }
    
    public static void SetNextBookId(int value) { _nextBookId = value; }
}