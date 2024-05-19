using System.Runtime.InteropServices;
using Data;
using Data.Inventory;
using Data.Users;

namespace Logic;

public interface ILibrary
{
    public static ILibrary New(IData? data = default)
    {
        return new Library(data);
    }

    public void CheckOutBooks(Customer customer, DateTime dueDate);
    public void RentBook(Book book, Customer customer, DateTime dueDate);
}