// Possibility of moving rented books from Catalog to a separate class (RentedCatalog)
using static Library.Data.IDataInterfaces;

namespace Library.Logic;
public class Rental
{
    private static int _nextRentalId = 1;
    private int _rentalId;           // { get; private set; }
    private IBook _rentedBook;        // { get; private set; }
    private ICustomer _rentedBy;      // { get; private set; }
    private DateTime _rentalDate;    // { get; private set; }
    private DateTime _dueDate;       // { get; private set; }

    public Rental(IBook rentedBook, ICustomer rentedBy, DateTime dueDate)
    {
        _rentalId = _nextRentalId;
        _rentedBook = rentedBook;
        _rentedBy = rentedBy;
        _rentalDate = DateTime.Now;
        _dueDate = dueDate;
        _nextRentalId++;
        rentedBook.SetIsAvailable(false);
    }
    
    public static int GetNextRentalId() { return _nextRentalId++; }
    
    public int GetRentalId() { return _rentalId; }
    
    public IBook GetRentedBook() { return _rentedBook; }
    
    public ICustomer GetRentedBy() { return _rentedBy; }
    
    public DateTime GetRentalDate() { return _rentalDate; }
    
    public DateTime GetDueDate() { return _dueDate; }
    
    public void ReturnBook()
    {
        if (_rentedBook.GetIsAvailable())
        {
            throw new InvalidOperationException("The book has already been returned.");
        }
        _rentedBook.SetIsAvailable(true);
    }

    public bool IsOverdue()
    {
        return DateTime.Now > _dueDate && !_rentedBook.GetIsAvailable();
    }

    public override string ToString()
    {
        var rentalStatus = _rentedBook.GetIsAvailable() ? "Returned" : "On Loan";
        return $"Rental ID: {_rentalId}\nBook Title: {_rentedBook.GetTitle()}\nRented By: {_rentedBy.GetName()}\n" +
               $"Rental Status: {rentalStatus}\nRental Date: {_rentalDate}\nDue Date: {_dueDate}";
    }
}