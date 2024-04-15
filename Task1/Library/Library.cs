using System;
using System.Collections.Generic;

namespace Task1
{
    public class Library
    {
        public void AddBook(Book book)
        {
            catalog[book.Name] = book;
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUser(string userName)
        {
            return users.Find(user => user.GetName() == userName);
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public void CheckoutBook(User user, string bookName)
        {
            if (catalog.ContainsKey(bookName))
            {
                Book book = catalog[bookName];
                userBooks[user.GetName()].Add(book);
                catalog.Remove(bookName);
                rentals.Add(new Rental(user, book, DateTime.Now));
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void ReturnBook(User user, string bookName)
        {
            if (userBooks.ContainsKey(user.GetName()))
            {
                List<Book> userBooksList = userBooks[user.GetName()];
                for (int i = 0; i < userBooksList.Count; i++)
                {
                    if (userBooksList[i].Name == bookName)
                    {
                        catalog[bookName] = userBooksList[i];
                        userBooksList.RemoveAt(i);
                        foreach (Rental rental in rentals)
                        {
                            if (rental.User == user && rental.Book == userBooksList[i])
                            {
                                rentals.Remove(rental);
                                break;
                            }
                        }
                        return;
                    }
                }
            }
            Console.WriteLine("Book not found.");
        }

        public List<Rental> GetRentals()
        {
            return rentals;
        }
        
        public Dictionary<string, Book> Catalog { get; } = new Dictionary<string, Book>();
        
        public DataContext DataContext { get; set; }
        public object UserBooks { get; set; }

        private Dictionary<string, Book> catalog = new Dictionary<string, Book>();
        private List<User> users = new List<User>();
        public Dictionary<string, List<Book>> userBooks = new Dictionary<string, List<Book>>();
        private List<Rental> rentals = new List<Rental>();
    }
}