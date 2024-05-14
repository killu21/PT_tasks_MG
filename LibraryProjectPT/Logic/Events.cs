// using Library.Data;
//
// namespace Library.Logic;
//
// public class Events
// {
//     private readonly List<IDataInterfaces.IBook> _books;
//     
//     
//     private readonly State _state;
//
//     public Events(State state)
//     {
//         _books = state.GetCurrentCatalog().GetBooks();
//         _state = state;
//     }
//
//     
//     public void CheckOutBooks(Customer customer, DateTime dueDate, Library library)
//     {
//         foreach (var book in _books)
//         {
//             if (!library.GetCatalog().GetBooks().Contains(book))
//             {
//                 throw new InvalidOperationException($"Book '{book.GetTitle()}' is not available in the library.");
//             }
//         }
//
//         if (!library.GetUsers().Contains(customer))
//         {
//             throw new InvalidOperationException($"User '{customer.GetName()}' is not registered with the library.");
//         }
//
//         foreach (var book in _books)
//         {
//             if (library.IsBookRented(book))
//             {
//                 throw new InvalidOperationException($"Book '{book.GetTitle()}' is already rented.");
//             }
//         }
//
//         // Rent the books
//         foreach (var book in _books)
//         {
//             library.RentBook(book, customer, dueDate);
//         }
//     }
//
//     public void ReturnBooks(Library library)
//     {
//         // Return the books
//         foreach (var book in _books)
//         {
//             library.ReturnBook(book);
//         }
//     }
//
//     public void AddBooksToCatalog(Book[] books)
//     {
//         if (_state == null)
//         {
//             throw new InvalidOperationException("State is null.");
//         }
//
//         var library = _state.GetCurrentLibrary();
//         if (library == null)
//         {
//             throw new InvalidOperationException("Library is null.");
//         }
//
//         foreach (var book in books)
//         {
//             library.AddBookToCatalog(book);
//         }
//     }
//
//     public void RemoveBooksFromCatalog(Book[] books)
//     {
//         if (_state == null)
//         {
//             throw new InvalidOperationException("State is null.");
//         }
//
//         var library = _state.GetCurrentLibrary();
//         if (library == null)
//         {
//             throw new InvalidOperationException("Library is null.");
//         }
//
//         if (books == null)
//         {
//             throw new ArgumentNullException(nameof(books));
//         }
//
//         foreach (var book in books)
//         {
//             if (book == null)
//             {
//                 throw new InvalidOperationException("Book is null.");
//             }
//             library.DeleteBookFromCatalog(book);
//         }
//     }
// }