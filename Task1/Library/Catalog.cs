using System.Collections.Generic;

namespace Library
{
    public class Catalog
    {
        private Dictionary<int, Book> books;

        public Catalog(Dictionary<int, Book> initialBooks = null)
        {
            books = initialBooks ?? new Dictionary<int, Book>();
        }

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
}