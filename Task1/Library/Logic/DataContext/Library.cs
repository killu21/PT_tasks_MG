using Library.Data;
using static Library.Data.IDataInterfaces;

namespace Library.Logic.DataContext;
public class Library
{
    private ICatalog _catalog;
    private List<IUser> _users;
    private readonly List<Rental> _rentals;

    public Library(ICatalog catalog, List<IUser> users, List<Rental> rentals)
    {
        _catalog = catalog;
        _users = users;
        _rentals = rentals;
    }
    
    public ICatalog GetCatalog() { return _catalog; }

    public List<IUser> GetUsers() { return _users; }
    
    public List<Rental> GetRentals() { return _rentals; }
    
    public void AddUser(IUser user)
    {
        _users.Add(user);
    }

    public void DeleteUser(IUser user)
    { 
        _users.Remove(user);
    }
    
    // Do we need that? Catalog class already has AddBook and RemoveBook methods. 
    // BUT - Checklist: `Logic` uses only the abstract `Data` layer API (?)
    public void AddBookToCatalog(IBook book)
    {
        _catalog.AddBook(book);
    }
    
    public void DeleteBookFromCatalog(IBook book)
    { 
        _catalog.RemoveBook(book);
    }

    // Do we need that? Now we can check if a book is rented by checking its isAvailable field.
    // BUT - Checklist: `Logic` uses only the abstract `Data` layer API (?)
    public bool IsBookRented(IBook book)
    {
        foreach (Rental rental in _rentals)
        {
            // !rental.GetRentedBook().GetIsAvailable() is too long, need to add a method isRented or sth
            if (rental.GetRentedBook() == book && !rental.GetRentedBook().GetIsAvailable())
            {
                return true;
            }
        }
        return false;
    }

    public void RentBook(IBook book, ICustomer customer, DateTime dueDate)
    {
        var rental = new Rental(book, customer, dueDate);
        _rentals.Add(rental);
    }

    // Same as above - do wee need that? But checklist: `Logic` uses only the abstract `Data` layer API
    public void ReturnBook(IBook book)
    {
        foreach (Rental rental in _rentals)
        {
            if (rental.GetRentedBook() == book && !rental.GetRentedBook().GetIsAvailable())
            {
                rental.ReturnBook(); 
                return;
            }
        }
        throw new InvalidOperationException("The specified book is not currently rented.");
    }
    
    public void UpdateLibraryState(State state)
    {
        _catalog = state.GetCurrentCatalog();
        _users = state.GetCurrentUsers();
    }
}