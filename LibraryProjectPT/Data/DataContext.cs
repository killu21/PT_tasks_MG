using System.Collections.Generic;
using Data.Inventory;
using Data.State;
using Data.Users;

namespace Data
{
    public class DataContext
    {
        public List<User> Users = new List<User>();
        public Dictionary<int, Book> Books = new Dictionary<int, Book>();
        public List<Rental> Rentals = new List<Rental>();
        public List<Catalog> Catalogs = new List<Catalog>();
    }
}