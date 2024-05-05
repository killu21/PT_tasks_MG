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
    
    public Catalog GetCatalog() { return _catalog; }

    public List<User> GetUsers() { return _users; }
    
    public List<Rental> GetRentals() { return _rentals; }
    
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void DeleteUser(User user)
    { 
        _users.Remove(user);
    }
    
    // Do we need that? Catalog class already has AddBook and RemoveBook methods. 
    // BUT - Checklist: `Logic` uses only the abstract `Data` layer API (?)
    public void AddBookToCatalog(Book book)
    {
        _catalog.AddBook(book);
    }
    
    public void DeleteBookFromCatalog(Book book)
    { 
        _catalog.RemoveBook(book);
    }

    // Do we need that? Now we can check if a book is rented by checking its isAvailable field.
    // BUT - Checklist: `Logic` uses only the abstract `Data` layer API (?)
    public bool IsBookRented(Book book)
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

    public void RentBook(Book book, Customer customer, DateTime dueDate)
    {
        var rental = new Rental(book, customer, dueDate);
        _rentals.Add(rental);
    }

    // Same as above - do wee need that? But checklist: `Logic` uses only the abstract `Data` layer API
    public void ReturnBook(Book book)
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
    // ?
    public void UpdateLibraryState(State state)
    {
        _catalog = new Catalog();
        foreach (var book in state.GetCurrentCatalog().GetBooks())
        {
            _catalog.AddBook(new Book(book.GetTitle(), book.GetAuthor(), book.GetIsAvailable()));
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
}