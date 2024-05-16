// namespace Data.Inventory;
// public class Book
// {
//     private int bookID;
//     private string title;
//     private string author;
//     private bool isAvailable;
//
//     public int BookID => bookID;
//     public string Title => title;
//     public string Author => author;
//     public bool IsAvailable
//     {
//         get => isAvailable;
//         set => isAvailable = value;
//     }
//
//     public Book(int _bookID, string _title, string _author, bool _isAvailable)
//     {
//         bookID = _bookID;
//         title = _title;
//         author = _author;
//         isAvailable = _isAvailable;
//     }
//     
// }

namespace Data.Inventory
{
    public abstract class Book
    {
        private int bookId;
        private string title;
        private string author;
        private bool isAvailable;

        public Book(int bookId, string title, string author, bool isAvailable)
        {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.isAvailable = isAvailable;
        }

        public abstract int GetBookId();
        public abstract string GetTitle();
        public abstract string GetAuthor();
        public abstract bool GetIsAvailable();
        public abstract void SetBookId(int value);
        public abstract void SetTitle(string value);
        public abstract void SetAuthor(string value);
        public abstract void SetIsAvailable(bool value);
    }
}