using System.Collections.Generic;

namespace Library;

public class State
{
    private Catalog _currentCatalog;
    private List<User> _currentUsers;

    public State(Library library)
    {
        _currentCatalog = new Catalog();
        foreach (var book in library.GetCatalog().GetBooks())
        { 
            _currentCatalog.AddBook(new Book(book.GetId(), book.GetTitle(), book.GetAuthor(), book.GetTerm()));
        }

        _currentUsers = new List<User>();
        foreach (var user in library.GetUsers())
        {
            if (user is Customer)
            {
                Customer customer = (Customer)user;
                _currentUsers.Add(new Customer(customer.GetSurname(), customer.GetName(), customer.GetPhone(), customer.GetCustomerId(), customer.GetBalance()));
            }
            else if (user is Staff)
            {
                Staff staff = (Staff)user;
                _currentUsers.Add(new Staff(staff.GetSurname(), staff.GetName(), staff.GetPhone(), staff.GetStaffId()));
            }
        }
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
        _currentCatalog = catalog;
    }

    public List<User> GetCurrentUsers()
    {
        return new List<User>(_currentUsers);
    }

    public void SetCurrentUsers(List<User> users)
    {
        _currentUsers = users;
    }
}