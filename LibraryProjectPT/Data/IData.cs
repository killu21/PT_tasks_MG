using Data.Inventory;
using Data.Users;

namespace Data;
public interface IData
{ 
    // ------------------- Books ------------------- //
    int GetBookId(int dictionaryKey);
    string GetBookTitle(int dictionaryKey);
    string GetBookAuthor(int dictionaryKey);
    bool GetIsBookAvailable(int dictionaryKey);
    void SetIsBookAvailable(int dictionaryKey, bool value);

    // ------------------- User ------------------- //
    string GetUserSurname(int id);
    void SetUserSurname(int id, string value);
    string GetUserName(int id);
    void SetUserName(int id, string value);
    int GetUserPhone(int id);
    void SetUserPhone(int id, int value);
    
    // ------------------- Customer ---------------- //
    // int GetCustomerId();
    int GetCustomerBalance(int id);
    void SetCustomerId(int id, int value);
    void SetCustomerBalance(int id, int value);
    
    // ------------------- Staff ------------------- //
    // int GetStaffId();
    void SetStaffId(int id, int value);
    
    // ------------------- Inventory ----------------- //
    void AddBook(Book book);
    void RemoveBook(Book book);
    Book GetBookFromCatalog(int dictionaryKey);
    
    // ------------------- Rental ------------------ //
    // int GetRentalId();
    Book GetRentedBook(int rentalId);
    Customer GetRentedBy(int rentalId);
    DateTime GetRentalDate(int rentalId);
    DateTime GetDueDate(int rentalId);
    bool IsOverdue(int rentalId);
    string RentalToString(int rentalId);
}