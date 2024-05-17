using System.Text;
using Data.Inventory;
using Data.Users;

namespace Data.State;
public class Rental
{
    public int RentalId { get; }
    public Book RentedBook { get; }
    public Customer RentedBy { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }

    private DateTime _rentalDate;
    private DateTime _dueDate;

    public Rental(int rentalId, Book rentedBook, Customer rentedBy, DateTime rentalDate, DateTime dueDate)
    {
        RentalId = rentalId;
        RentedBook = rentedBook;
        RentedBy = rentedBy;
        _rentalDate = rentalDate;
        _dueDate = dueDate;
    }
    
    public bool IsOverdue()
    {
        return DateTime.Now > _dueDate && !RentedBook.IsAvailable;
    }
    
    public string RentalToString()
    {
        var rentalStatus = RentedBook.IsAvailable ? "Returned" : "On Loan";
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Rental ID: {RentalId}");
        stringBuilder.AppendLine($"Book Title: {RentedBook.Title}");
        stringBuilder.AppendLine($"Rented By: {RentedBy.Name} {RentedBy.Surname}");
        stringBuilder.AppendLine($"Rental Status: {rentalStatus}");
        stringBuilder.AppendLine($"Rental Date: {_rentalDate}");
        stringBuilder.AppendLine($"Due Date: {_dueDate}");

        return stringBuilder.ToString();
    }

    // public int GetRentalId();
    // public Book GetRentedBook();
    // public Customer GetRentedBy();
    // public DateTime GetRentalDate();
    // public DateTime GetDueDate();
    // public bool IsOverdue();
    // public string RentalToString();
}