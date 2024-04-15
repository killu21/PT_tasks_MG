using System.Collections.Generic;

namespace Task1
{
    public interface ILibraryService
    {
        void AddBookToCatalog(int id, Book book);
        void AddUser(string surname, string name, int phone, string email);
        void CheckoutBook(string userName, string bookName);
        void ReturnBook(string userName, string bookName);
        List<Rental> GetRentals();
        User GetUser(string name);
    }
}