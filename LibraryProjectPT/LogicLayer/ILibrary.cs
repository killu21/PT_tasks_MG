using System.Runtime.InteropServices;
using DataLayer;
using DataLayer.Inventory;
using DataLayer.Users;

namespace Logic;

public interface ILibrary
{
    public static ILibrary New(IData? data = default)
    {
        return new Library(data);
    }

    public void RentBook(int bookId, int customerId, DateTime dueDate);
    public void ReturnBook(int bookId);
}