// using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace Task1
{
    public class DataContext
    {
        public List<User> Users { get; set; } = new List<User>();
        public Dictionary<int, Book> Catalog { get; set; } = new Dictionary<int, Book>();
        public ObservableCollection<Rental> Rentals { get; set; } = new ObservableCollection<Rental>();
        public List<Event> Events { get; set; } = new List<Event>();
    }
}