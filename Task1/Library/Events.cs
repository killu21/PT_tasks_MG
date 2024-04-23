using System;


namespace Library
{
    public class Events
    {
        public void CheckOutBooks(Book[] books, User user, DateTime rentalDate, DateTime dueDate, Library library)
        {
            foreach (var book in books)
            {
                if (!library.GetCatalog().GetBooks().Contains(book))
                {
                    throw new InvalidOperationException($"Book '{book.GetTitle()}' is not available in the library.");
                }
            }

            if (!library.GetUsers().Contains(user))
            {
                throw new InvalidOperationException($"User '{user.GetName()}' is not registered with the library.");
            }

            foreach (var book in books)
            {
                if (library.IsBookRented(book))
                {
                    throw new InvalidOperationException($"Book '{book.GetTitle()}' is already rented.");
                }
            }

            // Rent the books
            foreach (var book in books)
            {
                library.RentBook(book, user, rentalDate, dueDate);
            }
        }

        public void ReturnBooks(Book[] books, Library library)
        {
            // Return the books
            foreach (var book in books)
            {
                library.ReturnBook(book);
            }
        }

        public void AddBooksToCatalog(Book[] books, Library library)
        {
            foreach (var book in books)
            {
                library.AddBook(book);
            }
        }

        public void RemoveBooksFromCatalog(Book[] books, Library library)
        {
            foreach (var book in books)
            {
                library.DeleteBook(book);
            }
        }
    }
}