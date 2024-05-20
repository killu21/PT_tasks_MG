using System.Text;
using DataLayer.Inventory;
using DataLayer.Users;

namespace DataLayer.State;
public class Rental
{
    public Guid RentalId { get; }
    public Book RentedBook { get; }
    public Customer RentedBy { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }
    private readonly DateTime _rentalDate;
    private readonly DateTime _dueDate;

    public Rental(Guid rentalId, Book rentedBook, Customer rentedBy, DateTime rentalDate, DateTime dueDate)
    {   // Remove rentalDate from constructor parameters and in body do _rentalDate = DateTime.Now
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
}