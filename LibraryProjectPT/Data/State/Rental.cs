using System;
using Data.Inventory;
using Data.Users;

namespace Data.State
{
    public abstract class Rental
    {
        private int rentalId;
        private Book rentedBook;
        private Customer rentedBy;
        private DateTime rentalDate;
        private DateTime dueDate;

        public Rental(int rentalId, Book rentedBook, Customer rentedBy, DateTime rentalDate, DateTime dueDate)
        {
            this.rentalId = rentalId;
            this.rentedBook = rentedBook;
            this.rentedBy = rentedBy;
            this.rentalDate = rentalDate;
            this.dueDate = dueDate;
        }

        public abstract int GetRentalId();
        public abstract Book GetRentedBook();
        public abstract Customer GetRentedBy();
        public abstract DateTime GetRentalDate();
        public abstract DateTime GetDueDate();
        public abstract bool IsOverdue();
        public abstract string RentalToString();
    }
}