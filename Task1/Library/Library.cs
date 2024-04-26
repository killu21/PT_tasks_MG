using System.Collections.Generic;

namespace Library;

public class Library
{
    private Catalog _catalog;
    private List<User> _users;
    private double _initialFunds;
    private readonly List<Rental> rentals;

    public Library(double initialFunds)
    {
            this._catalog = new Catalog();
            this._users = new List<User>();
            this._initialFunds = initialFunds;
            this.rentals = new List<Rental>();
        }
        
    public double GetInitialFunds()
    {
            return _initialFunds;
        }
        
    public void UpdateLibraryState(State state)
    {
            this._catalog = new Catalog();
            foreach (var book in state.GetCurrentCatalog().GetBooks())
            {
                this._catalog.AddBook(new Book(book.GetId(), book.GetTitle(), book.GetAuthor(), book.GetTerm()));
            }

            this._users = new List<User>();
            foreach (var user in state.GetCurrentUsers())
            {
                if (user is Staff)
                {
                    Staff staff = (Staff)user;
                    this._users.Add(new Staff(staff.GetSurname(), staff.GetName(), staff.GetPhone(), staff.GetStaffId(), staff.GetSalary()));
                }
                else if (user is Customer)
                {
                    Customer customer = (Customer)user;
                    this._users.Add(new Customer(customer.GetSurname(), customer.GetName(), customer.GetPhone(), customer.GetCustomerId(), customer.GetBalance()));
                }
            }

            this._initialFunds = state.GetCurrentFunds();
        }

    public Catalog GetCatalog()
    {
            return _catalog;
        }

    public List<User> GetUsers()
    {
            return _users;
        }

    public double GetFunds()
    {
            return _initialFunds;
        }

    public void AddUser(User user)
    {
            _users.Add(user);
        }

    public void DeleteUser(User user)
    {
            _users.Remove(user);
        }

    public void SetFunds(double funds)
    {
            _initialFunds = funds;
        }
        
    public void AddBook(Book book)
    {
            _catalog.AddBook(book);
        }

    public void DeleteBook(Book book)
    {
            _catalog.RemoveBook(book);
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