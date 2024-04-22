using System.Collections.Generic;

namespace Library
{
    public class State
    {
        private Catalog currentCatalog;
        private List<User> currentUsers;
        private double currentFunds;

        public State(Library library)
        {
            this.currentCatalog = new Catalog();
            foreach (var book in library.GetCatalog().GetBooks())
            {
                this.currentCatalog.AddBook(new Book(book.GetId(), book.GetTitle(), book.GetAuthor(), book.GetTerm()));
            }

            this.currentUsers = new List<User>();
            foreach (var user in library.GetUsers())
            {
                if (user is Customer)
                {
                    Customer customer = (Customer)user;
                    this.currentUsers.Add(new Customer(customer.GetSurname(), customer.GetName(), customer.GetPhone(), customer.GetCustomerId(), customer.GetBalance()));
                }
                else if (user is Staff)
                {
                    Staff staff = (Staff)user;
                    this.currentUsers.Add(new Staff(staff.GetSurname(), staff.GetName(), staff.GetPhone(), staff.GetStaffId(), staff.GetSalary()));
                }
            }

            this.currentFunds = library.GetFunds();
        }

        public Catalog GetCurrentCatalog()
        {
            Dictionary<int, Book> bookDictionary = new Dictionary<int, Book>();
            foreach (var book in currentCatalog.GetBooks())
            {
                bookDictionary.Add(book.GetId(), book);
            }
            return new Catalog(bookDictionary);
        }

        public void SetCurrentCatalog(Catalog catalog)
        {
            this.currentCatalog = catalog;
        }

        public List<User> GetCurrentUsers()
        {
            return new List<User>(currentUsers);
        }

        public void SetCurrentUsers(List<User> users)
        {
            this.currentUsers = users;
        }

        public double GetCurrentFunds()
        {
            return currentFunds;
        }

        public void SetCurrentFunds(double value)
        {
            this.currentFunds = value;
        }
    }
}
