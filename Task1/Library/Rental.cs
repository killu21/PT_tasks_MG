using System;

namespace Library;

public class Rental
{
    public int RentalId { get; private set; }
    private static int _nextRentalId = 1;
    public Book RentedBook { get; private set; }
    public User RentedBy { get; private set; }
    public DateTime RentalDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsReturned { get; private set; }

    public Rental(int rentalId, Book rentedBook, User rentedBy, DateTime rentalDate, DateTime dueDate)
    {
        RentalId = rentalId;
        RentedBook = rentedBook;
        RentedBy = rentedBy;
        RentalDate = rentalDate;
        DueDate = dueDate;
        IsReturned = false;
    }
              
    public static int GetNextRentalId()
    {
        return _nextRentalId++;
    }

    public void ReturnBook()
    {
        if (IsReturned)
        {
            throw new InvalidOperationException("The book has already been returned.");
        }
        IsReturned = true;
    }

    public bool IsOverdue()
    {
        return DateTime.Now > DueDate && !IsReturned;
    }

    public override string ToString()
    {
        string rentalStatus = IsReturned ? "Returned" : "On Loan";
        return $"Rental ID: {RentalId}\nBook Title: {RentedBook.GetTitle()}\nRented By: {RentedBy.GetName()}\nRental Status: {rentalStatus}\n";
    }
}