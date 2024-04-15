using System;

namespace Task1
{
    public class Rental
    {
        public Rental(User user, Book book, DateTime rentalDate)
        {
            User = user;
            Book = book;
            RentalDate = rentalDate;
        }

        public User User { get; }
        public Book Book { get; }
        public DateTime RentalDate { get; }
    }
}