using Data.Inventory;
using Data.State;
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
    long GetUserPhone(int id);
    void SetUserPhone(int id, int value);
    public List<User> GetUsers();
    
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
    public List<Book> GetAllBooksFromCatalog();
    
    // ------------------- Rental ------------------ //
    // int GetRentalId();
    Book GetRentedBook(Guid rentalId);
    Customer GetRentedBy(Guid rentalId);
    DateTime GetRentalDate(Guid rentalId);
    DateTime GetDueDate(Guid rentalId);
    bool IsOverdue(Guid rentalId);
    string RentalToString(Guid rentalId);
    void AddRental(Rental rental);
    public List<Rental> GetRentals();
}