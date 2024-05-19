using Data;
using Data.Inventory;
using Data.State;
using Data.Users;

namespace Logic
{
    public class Library : ILibrary
    {
        private IData data;
        

        public Library(IData? data = default)
        {
            this.data = data ?? new Data.Data();
        }
        
        public void CheckOutBooks(Customer customer, DateTime dueDate)
        {
            // Get all books from the catalog
            var books = data.GetAllBooksFromCatalog();

            // Check if the customer is registered
            if (!data.GetUsers().Contains(customer))
            {
                throw new InvalidOperationException($"User '{customer.Name}' is not registered with the library.");
            }

            // Check each book
            foreach (var book in books)
            {
                // Check if the book is available in the library
                if (!book.IsAvailable)
                {
                    throw new InvalidOperationException($"Book '{book.Title}' is not available in the library.");
                }

                // Check if the book is already rented
                foreach (var rental in data.GetRentals())
                {
                    if (rental.RentedBook.BookId == book.BookId && !rental.RentedBook.IsAvailable)
                    {
                        throw new InvalidOperationException($"Book '{book.Title}' is already rented.");
                    }
                }
            }
        }
        
        public void RentBook(Book book, Customer customer, DateTime dueDate)
        {
            // Check if the book is available
            if (book.IsAvailable)
            {
                // Set the book as not available
                data.SetIsBookAvailable(book.BookId, false);

                // Create a new rental
                Rental rental = new Rental(Guid.NewGuid() ,book, customer, DateTime.Now, dueDate);
                data.AddRental(rental);
            }
            else
            {
                throw new InvalidOperationException($"Book '{book.Title}' is already rented.");
            }
        }
        
    }
}   