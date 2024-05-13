using Data.Inventory;
using System.Text;
using Data.Users;

namespace Data.State;
public class Rental
{
    private readonly int _rentalId;
    private readonly Book _rentedBook;
    private readonly Customer _rentedBy;
    private readonly DateTime _rentalDate;
    private readonly DateTime _dueDate;

    public Rental(int rentalId, Book rentedBook, Customer rentedBy, DateTime dueDate)
    {
        _rentalId = rentalId;
        _rentedBook = rentedBook;
        _rentedBy = rentedBy;
        _rentalDate = DateTime.Now;
        _dueDate = dueDate;
        rentedBook.SetIsAvailable(false);
    }
    
    public int GetRentalId() { return _rentalId; }
    
    public Book GetRentedBook() { return _rentedBook; }
    
    public Customer GetRentedBy() { return _rentedBy; }
    
    public DateTime GetRentalDate() { return _rentalDate; }
    
    public DateTime GetDueDate() { return _dueDate; }
    
    // not here
    // public void ReturnBook()
    // {
    //     if (_rentedBook.GetIsAvailable())
    //     {
    //         throw new InvalidOperationException("The book has already been returned.");
    //     }
    //     _rentedBook.SetIsAvailable(true);
    // }

    public bool IsOverdue()
    {
        return DateTime.Now > _dueDate && !_rentedBook.GetIsAvailable();
    }

    public string RentalToString()
    {
        var rentalStatus = _rentedBook.GetIsAvailable() ? "Returned" : "On Loan";
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Rental ID: {_rentalId}");
        stringBuilder.AppendLine($"Book Title: {_rentedBook.GetTitle()}");
        stringBuilder.AppendLine($"Rented By: {_rentedBy.GetName()}");
        stringBuilder.AppendLine($"Rental Status: {rentalStatus}");
        stringBuilder.AppendLine($"Rental Date: {_rentalDate}");
        stringBuilder.AppendLine($"Due Date: {_dueDate}");

        return stringBuilder.ToString();
    }
}