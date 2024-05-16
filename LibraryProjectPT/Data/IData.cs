using Data.Inventory;
using Data.State;
using Data.Users;

namespace Data;
public interface IData
{ 
    // ------------------- Books ------------------- //
    int GetId();
    string GetTitle();
    string GetAuthor();
    bool GetIsAvailable();
    void SetIsAvailable(bool value);

    // ------------------- User ------------------- //
    string GetSurname();
    void SetSurname(string value);
    string GetName();
    void SetName(string value);
    int GetPhone();
    void SetPhone(int value);
    
    // ------------------- Customer ---------------- //
    int GetCustomerId();
    int GetBalance();
    void SetCustomerId(int value);
    void SetBalance(int value);
    
    // ------------------- Staff ------------------- //
    int GetStaffId();
    void SetStaffId(int value);
    
    // ------------------- Catalog ----------------- //
    void AddBook(Book book);
    void RemoveBook(Book book);
    List<Book> GetBooks();
    
    // ------------------- Rental ------------------ //
    int GetRentalId();
    Book GetRentedBook();
    Customer GetRentedBy();
    DateTime GetRentalDate();
    DateTime GetDueDate();
    bool IsOverdue();
    string RentalToString();
}