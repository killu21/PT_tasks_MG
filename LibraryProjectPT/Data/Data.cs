using System;
using System.Collections.Generic;
using Data.Inventory;
using Data.Users;
using Data.State;

namespace Data
{
    public class Data : IData
    {
        private DataContext context;

        public Data(DataContext context)
        {
            this.context = context;
        }
       

        // ------------------- Books ------------------- //

        public int GetId()
        {
            var book = GetDefaultBook();
            return book.GetBookId();
        }

        public string GetTitle()
        {
            var book = GetDefaultBook();
            return book.GetTitle();
        }

        public string GetAuthor()
        {
            var book = GetDefaultBook();
            return book.GetAuthor();
        }

        public bool GetIsAvailable()
        {
            var book = GetDefaultBook();
            return book.GetIsAvailable();
        }

        public void SetIsAvailable(bool value)
        {
            var book = GetDefaultBook();
            book.SetIsAvailable(value);
        }

        private Book GetDefaultBook()
        {
            // Replace with your logic to get the default or currently selected book
            return context.Books.First().Value;
        }

        // ------------------- User ------------------- //
        public string GetSurname()
        {
            // Replace with your logic to get the default or currently selected user
            var user = GetDefaultUser();
            return user.GetSurname();
        }

        public void SetSurname(string value)
        {
            var user = GetDefaultUser();
            user.SetSurname(value);
        }

        public string GetName()
        {
            var user = GetDefaultUser();
            return user.GetName();
        }

        public void SetName(string value)
        {
            var user = GetDefaultUser();
            user.SetName(value);
        }

        public int GetPhone()
        {
            var user = GetDefaultUser();
            return user.GetPhone();
        }

        public void SetPhone(int value)
        {
            var user = GetDefaultUser();
            user.SetPhone(value);
        }

        private User GetDefaultUser()
        {
            // Replace with your logic to get the default or currently selected user
            return context.Users.First();
        }

        // ------------------- Customer ---------------- //
        public int GetCustomerId()
        {
            var customer = GetDefaultCustomer();
            return customer.GetCustomerId();
        }

        public int GetBalance()
        {
            var customer = GetDefaultCustomer();
            return customer.GetBalance();
        }

        public void SetCustomerId(int value)
        {
            var customer = GetDefaultCustomer();
            customer.SetCustomerId(value);
        }

        public void SetBalance(int value)
        {
            var customer = GetDefaultCustomer();
            customer.SetBalance(value);
        }

        private Customer GetDefaultCustomer()
        {
            // Replace with your logic to get the default or currently selected customer
            return (Customer)context.Users.First();
        }

        // ------------------- Staff ------------------- //
        public int GetStaffId()
        {
            var staff = GetDefaultStaff();
            return staff.GetStaffId();
        }

        public void SetStaffId(int value)
        {
            var staff = GetDefaultStaff();
            staff.SetStaffId(value);
        }

        private Staff GetDefaultStaff()
        {
            // Replace with your logic to get the default or currently selected staff member
            return (Staff)context.Users.First();
        }

        // ------------------- Catalog ----------------- //
        public void AddBook(Book book)
        {
            var catalog = GetDefaultCatalog();
            catalog.AddBook(book);
        }

        public void RemoveBook(Book book)
        {
            var catalog = GetDefaultCatalog();
            catalog.RemoveBook(book);
        }

        public List<Book> GetBooks()
        {
            var catalog = GetDefaultCatalog();
            return catalog.GetBooks();
        }

        private Catalog GetDefaultCatalog()
        {
            // Replace with your logic to get the default or currently selected catalog
            return context.Catalogs.First();
        }
        // ------------------- Rental ------------------ //
        public int GetRentalId()
        {
            var rental = GetDefaultRental();
            return rental.GetRentalId();
        }

        public Book GetRentedBook()
        {
            var rental = GetDefaultRental();
            return rental.GetRentedBook();
        }

        public Customer GetRentedBy()
        {
            var rental = GetDefaultRental();
            return rental.GetRentedBy();
        }

        public DateTime GetRentalDate()
        {
            var rental = GetDefaultRental();
            return rental.GetRentalDate();
        }

        public DateTime GetDueDate()
        {
            var rental = GetDefaultRental();
            return rental.GetDueDate();
        }

        public bool IsOverdue()
        {
            var rental = GetDefaultRental();
            return rental.IsOverdue();
        }

        public string RentalToString()
        {
            var rental = GetDefaultRental();
            return rental.RentalToString();
        }

        private Rental GetDefaultRental()
        {
            // Replace with your logic to get the default or currently selected rental
            return context.Rentals.First();
        }
    }
}