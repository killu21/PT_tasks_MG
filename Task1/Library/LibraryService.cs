using System;
using System.Collections.Generic;
using System.Linq;
using Task1;

namespace Task1
{
    public class LibraryService
    {
        private Library _library;

        public LibraryService()
        {
            _library = new Library();
        }

        public void AddBook(string name)
        {
            _library.AddBook(new Book(name));
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
            return _library.GetUsers().FirstOrDefault(u => string.Equals(u.GetName(), name, StringComparison.OrdinalIgnoreCase));
        }

    }
}