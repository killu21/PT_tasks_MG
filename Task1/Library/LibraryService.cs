using System;
using System.Collections.Generic;
using System.Linq;
// using Task1;

namespace Task1
{
    public class LibraryService : ILibraryService
    {
        private Library _library;
        private readonly DataContext _dataContext;

        public LibraryService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _library = new Library(); 
            _library.DataContext = _dataContext; 
        }

        public LibraryService()
        {
            _library = new Library();
            _library.DataContext = new DataContext();
        }

        // public void AddBook(string name)
        // {
        //     _library.AddBook(new Book(name));
        // }

        public void AddBookToCatalog(int id, Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }

            if (_dataContext.Catalog.ContainsKey(id))
            {
                throw new ArgumentException($"A book with ID {id} already exists in the catalog.");
            }

            _dataContext.Catalog[id] = book;
            _dataContext.Events.Add(new Event { Description = $"Book with ID {id} added", Time = DateTime.Now });
        }


        public void AddUser(string surname, string name, int phone, string email)
        {
            _library.AddUser(new User(surname, name, phone, email));
        }

        public void CheckoutBook(string userName, string bookName)
        {
            User user = _library.GetUser(userName);
            if (user != null)
            {
                _library.CheckoutBook(user, bookName);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void ReturnBook(string userName, string bookName)
        {
            User user = _library.GetUser(userName);
            if (user != null)
            {
                _library.ReturnBook(user, bookName);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public List<Rental> GetRentals()
        {
            return _library.GetRentals();
        }

        public User GetUser(string name)
        {
            return _library.GetUsers()
                .FirstOrDefault(u => string.Equals(u.GetName(), name, StringComparison.OrdinalIgnoreCase));
        }
        


        public Library GetLibrary()
        {
            return _library;
        }

        public Book GetBook(int id)
        {
            if (_library.DataContext.Catalog.ContainsKey(id))
            {
                return _library.DataContext.Catalog[id];
            }
            else
            {
                return null;
            }
        }
    }
}