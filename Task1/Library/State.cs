using System.Collections.Generic;

namespace Library;

public class State
{
    private Catalog _currentCatalog;
    private List<User> _currentUsers;
    private double _currentFunds;

    public State(Library library)
    {
        this._currentCatalog = new Catalog();
        foreach (var book in library.GetCatalog().GetBooks())
        {
            this._currentCatalog.AddBook(new Book(book.GetId(), book.GetTitle(), book.GetAuthor(), book.GetTerm()));
        }

        this._currentUsers = new List<User>();
        foreach (var user in library.GetUsers())
        {
            if (user is Customer)
            {
                Customer customer = (Customer)user;
                this._currentUsers.Add(new Customer(customer.GetSurname(), customer.GetName(), customer.GetPhone(), customer.GetCustomerId(), customer.GetBalance()));
            }
            else if (user is Staff)
            {
                Staff staff = (Staff)user;
                this._currentUsers.Add(new Staff(staff.GetSurname(), staff.GetName(), staff.GetPhone(), staff.GetStaffId(), staff.GetSalary()));
            }
        }

        this._currentFunds = library.GetFunds();
    }

    public Catalog GetCurrentCatalog()
    {
        Dictionary<int, Book> bookDictionary = new Dictionary<int, Book>();
        foreach (var book in _currentCatalog.GetBooks())
        {
            bookDictionary.Add(book.GetId(), book);
        }
        return new Catalog(bookDictionary);
    }

    public void SetCurrentCatalog(Catalog catalog)
    {
        this._currentCatalog = catalog;
    }

    public List<User> GetCurrentUsers()
    {
        return new List<User>(_currentUsers);
    }

    public void SetCurrentUsers(List<User> users)
    {
        this._currentUsers = users;
    }

    public double GetCurrentFunds()
    {
        return _currentFunds;
    }

    public void SetCurrentFunds(double value)
    {
        this._currentFunds = value;
    }
}