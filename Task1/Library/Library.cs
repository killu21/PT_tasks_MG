using System.Collections.Generic;

namespace Library
{
    public class Library
    {
        private Catalog catalog;
        private List<User> users;
        private double initialFunds;
        private List<Rental> rentals;

        public Library(double initialFunds)
        {
            this.catalog = new Catalog();
            this.users = new List<User>();
            this.initialFunds = initialFunds;
            this.rentals = new List<Rental>();
        }
        
        public double GetInitialFunds()
        {
            return initialFunds;
        }
        
        public void UpdateLibraryState(State state)
        {
            this.catalog = new Catalog();
            foreach (var book in state.GetCurrentCatalog().GetBooks())
            {
                this.catalog.AddBook(new Book(book.GetId(), book.GetTitle(), book.GetAuthor(), book.GetTerm()));
            }

            this.users = new List<User>();
            foreach (var user in state.GetCurrentUsers())
            {
                if (user is Staff)
                {
                    Staff staff = (Staff)user;
                    this.users.Add(new Staff(staff.GetSurname(), staff.GetName(), staff.GetPhone(), staff.GetStaffId(), staff.GetSalary()));
                }
                else if (user is Customer)
                {
                    Customer customer = (Customer)user;
                    this.users.Add(new Customer(customer.GetSurname(), customer.GetName(), customer.GetPhone(), customer.GetCustomerId(), customer.GetBalance()));
                }
            }

            this.initialFunds = state.GetCurrentFunds();
        }

        public Catalog GetCatalog()
        {
            return catalog;
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public double GetFunds()
        {
            return initialFunds;
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public void SetFunds(double funds)
        {
            initialFunds = funds;
        }
        
        public void AddBook(Book book)
        {
            catalog.AddBook(book);
        }

        public void DeleteBook(Book book)
        {
            catalog.RemoveBook(book);
        }


        public bool IsBookRented(Book book)
        {
            foreach (Rental rental in rentals)
            {
                if (rental.RentedBook == book && !rental.IsReturned)
                {
                    return true;
                }
            }
            return false;
        }

        public void RentBook(Book book, User user, DateTime rentalDate, DateTime dueDate)
        {
            Rental rental = new Rental(Rental.GetNextRentalId(), book, user, rentalDate, dueDate);
            rentals.Add(rental);
        }

        public void ReturnBook(Book book)
        {
            foreach (Rental rental in rentals)
            {
                if (rental.RentedBook == book && !rental.IsReturned)
                {
                    rental.ReturnBook(); 
                    return;
                }
            }
            throw new InvalidOperationException("The specified book is not currently rented.");
        }
    }
}
