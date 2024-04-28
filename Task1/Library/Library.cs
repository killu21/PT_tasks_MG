using System.Collections.Generic;

namespace Library;

public class Library
{
    private Catalog _catalog;
    private List<User> _users;
    private readonly List<Rental> _rentals;

    public Library()
    {
        _catalog = new Catalog();
        _users = new List<User>();
        _rentals = new List<Rental>();
    }
    
    public void UpdateLibraryState(State state)
    {
        _catalog = new Catalog();
        foreach (var book in state.GetCurrentCatalog().GetBooks())
        {
            _catalog.AddBook(new Book(book.GetId(), book.GetTitle(), book.GetAuthor(), book.GetTerm()));
        }

        _users = new List<User>();
        foreach (var user in state.GetCurrentUsers())
        {
            if (user is Staff)
            {
                Staff staff = (Staff)user;
                _users.Add(new Staff(staff.GetSurname(), staff.GetName(), staff.GetPhone(), staff.GetStaffId()));
            }
            else if (user is Customer)
            {
                Customer customer = (Customer)user;
                _users.Add(new Customer(customer.GetSurname(), customer.GetName(), customer.GetPhone(), customer.GetCustomerId(), customer.GetBalance()));
            }
        }
    }

    public Catalog GetCatalog() { return _catalog; }

    public List<User> GetUsers() { return _users; }
    
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void DeleteUser(User user)
    { 
        _users.Remove(user);
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
        foreach (Rental rental in _rentals)
        {
            if (rental.RentedBook == book && !rental.IsReturned)
            {
                return true;
            }
        }
        return false;
    }

    public void RentBook(Book book, Customer customer, DateTime rentalDate, DateTime dueDate)
    {
        Rental rental = new Rental(Rental.GetNextRentalId(), book, customer, rentalDate, dueDate);
        _rentals.Add(rental);
    }

    public void ReturnBook(Book book)
    {
        foreach (Rental rental in _rentals)
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