using System.Collections.Generic;
using Data.Inventory;

namespace Data.State
{
    public abstract class Catalog
    {
        private Dictionary<int, Book> books;

        public Catalog(Dictionary<int, Book> books)
        {
            this.books = books;
        }

        public abstract void AddBook(Book book);
        public abstract void RemoveBook(Book book);
        public abstract List<Book> GetBooks();
    }
}