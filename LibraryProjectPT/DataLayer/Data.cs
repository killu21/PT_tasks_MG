using DataLayer.Inventory;
using DataLayer.Users;
using DataLayer.State;

namespace DataLayer;

public class Data : IData
{
    private readonly DataRepository _repository;
    
    public Data()
    {
        _repository = new DataRepository();
    }

    public Data(DataRepository repository)
    {
        _repository = repository;
    }
    
    // ------------------- Books ------------------- //
    public int GetBookId(int bookId)     // bookId is actually the bookId so this method is redundant
    {
        if (_repository.BooksCatalog.books.TryGetValue(bookId, out var book))
        {
            return book.BookId;
        }
        
        throw new KeyNotFoundException("The provided key was not found in the BooksDictionary.");
    }

    public string GetBookTitle(int bookId)
    {
        if (_repository.BooksCatalog.books.TryGetValue(bookId, out var book))
        {
            return book.Title;
        }
        
        throw new KeyNotFoundException("The provided key was not found in the BooksDictionary.");
    }

    public string GetBookAuthor(int bookId)
    {
        if (_repository.BooksCatalog.books.TryGetValue(bookId, out var book))
        {
            return book.Author;
        }
        
        throw new KeyNotFoundException("The provided key was not found in the BooksDictionary.");
    }
    
    public bool GetIsBookAvailable(int bookId)
    {
        if (_repository.BooksCatalog.books.TryGetValue(bookId, out var book))
        {
            return book.IsAvailable;
        }
        
        throw new KeyNotFoundException("The provided key was not found in the BooksDictionary.");
    }

    public void SetIsBookAvailable(int bookId, bool value)
    {
        if (_repository.BooksCatalog.books.TryGetValue(bookId, out var book))
        {
            book.IsAvailable = value;
        }
        else
        {
            throw new KeyNotFoundException("The provided key was not found in the BooksDictionary.");
        }
    }
    
    // ------------------- User ------------------- //
    // Assuming that the ID is unique:
    // Customers id range from 1 to 1000
    // Staff id range from 1001 to 2000
    
    public User GetUser(int userId)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == userId)
            {
                return customer;
            }
            if (user is Staff staff && staff.StaffId == userId)
            {
                return staff;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }
    public string GetUserSurname(int id)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == id)
            {
                return customer.Surname;
            }
            if (user is Staff staff && staff.StaffId == id)
            {
                return staff.Surname;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }

    public void SetUserSurname(int id, string value)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == id)
            {
                customer.Surname = value;
            }
            if (user is Staff staff && staff.StaffId == id)
            {
                staff.Surname = value;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }

    public string GetUserName(int id)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == id)
            {
                return customer.Name;
            }
            if (user is Staff staff && staff.StaffId == id)
            {
                return staff.Name;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }

    public void SetUserName(int id, string value)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == id)
            {
                customer.Name = value;
            }

            if (user is Staff staff && staff.StaffId == id)
            {
                staff.Name = value;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }

    public long GetUserPhone(int id)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == id)
            {
                return customer.Phone;
            }

            if (user is Staff staff && staff.StaffId == id)
            {
                return staff.Phone;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }

    public void SetUserPhone(int id, int value)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == id)
            {
                customer.Phone = (uint)value;
            }

            if (user is Staff staff && staff.StaffId == id)
            {
                staff.Phone = (uint)value;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }
    
    public List<User> GetUsers()
    {
        return _repository.UsersList;
    }
    
    // ------------------- Customer ---------------- //
    // public int GetCustomerId() // Maybe search by surname name and phone
    // {
    //     return 0;
    // }

    // public int GetCustomerBalance(int id)
    // {
    //     foreach (var user in _repository.UsersList)
    //     {
    //         if (user is Customer customer && customer.CustomerId == id)
    //         {
    //             return customer.Balance;
    //         }
    //     }
    //
    //     throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    // }

    public void SetCustomerId(int id, int value)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Customer customer && customer.CustomerId == id)
            {
                customer.CustomerId = value;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }

    // public void SetCustomerBalance(int id, int value)
    // {
    //     foreach (var user in _repository.UsersList)
    //     {
    //         if (user is Customer customer && customer.CustomerId == id)
    //         {
    //             customer.Balance = value;
    //         }
    //     }
    //
    //     throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    // }

    // ------------------- Staff ------------------- //
    // public int GetStaffId() // Maybe search by surname name and phone
    // {
    //     return 0;
    // }

    public void SetStaffId(int id, int value)
    {
        foreach (var user in _repository.UsersList)
        {
            if (user is Staff staff && staff.StaffId == id)
            {
                staff.StaffId = value;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Users list.");
    }
    
    // ------------------- Inventory ----------------- //
    public void AddBook(Book book)
    {
        _repository.BooksCatalog.AddBookToCatalog(book);
    }

    public void RemoveBook(Book book)
    {
        _repository.BooksCatalog.RemoveBookFromCatalog(book);
    }

    public Book GetBookFromCatalog(int bookId)
    {
        return _repository.BooksCatalog.GetBookFromCatalog(bookId);
    }
    
    public List<Book> GetAllBooksFromCatalog()
    {
        return new List<Book>(_repository.BooksCatalog.books.Values);
    }
    
    // ------------------- Rental ------------------ //
    // public int GetRentalId() // Maybe search by rentedBook and rentedBy
    // {
    //     return 0;
    // }

    public Book GetRentedBook(Guid rentalId)
    {
        foreach (var rental in _repository.RentalsList)
        {
            if (rental.RentalId == rentalId)
            {
                return rental.RentedBook;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Rentals list.");
    }
    
    public Customer GetRentedBy(Guid rentalId)
    {
        foreach (var rental in _repository.RentalsList)
        {
            if (rental.RentalId == rentalId)
            {
                return rental.RentedBy;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Rentals list.");
    }

    public DateTime GetRentalDate(Guid rentalId)
    {
        foreach (var rental in _repository.RentalsList)
        {
            if (rental.RentalId == rentalId)
            {
                return rental.RentalDate;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Rentals list.");
    }

    public DateTime GetDueDate(Guid rentalId)
    {
        foreach (var rental in _repository.RentalsList)
        {
            if (rental.RentalId == rentalId)
            {
                return rental.DueDate;
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Rentals list.");
    }

    public bool IsOverdue(Guid rentalId)
    {
        foreach (var rental in _repository.RentalsList)
        {
            if (rental.RentalId == rentalId)
            {
                return rental.IsOverdue();
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Rentals list.");
    }
    
    public string RentalToString(Guid rentalId)
    {
        foreach (var rental in _repository.RentalsList)
        {
            if (rental.RentalId == rentalId)
            {
                return rental.RentalToString();
            }
        }

        throw new KeyNotFoundException("The provided ID was not found in the Rentals list.");
    }

    public void AddRental(Rental rental)
    {
        _repository.RentalsList.Add(rental);
    }
    
    public List<Rental> GetRentals()
    {
        return _repository.RentalsList;
    }
    
    public void RemoveRental(Rental rental)
    {
        _repository.RentalsList.Remove(rental);
    }
}