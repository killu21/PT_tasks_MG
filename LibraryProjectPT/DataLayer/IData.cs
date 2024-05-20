using DataLayer.Inventory;
using DataLayer.State;
using DataLayer.Users;

namespace DataLayer;

public interface IData
{ 
   
    // ------------------- Books ------------------- //
    int GetBookId(int dictionaryKey);   // dictionaryKey is actually the bookId so this method is redundant
    string GetBookTitle(int dictionaryKey);
    string GetBookAuthor(int dictionaryKey);
    bool GetIsBookAvailable(int dictionaryKey);
    void SetIsBookAvailable(int dictionaryKey, bool value);

    // ------------------- User ------------------- //
    string GetUserSurname(int userId);
    void SetUserSurname(int userId, string value);
    string GetUserName(int userId);
    void SetUserName(int userId, string value);
    long GetUserPhone(int userId);
    void SetUserPhone(int userId, int value);
    public List<User> GetUsers();
    
    // ------------------- Customer ---------------- //
    // int GetCustomerId();
    // int GetCustomerBalance(int id);
    void SetCustomerId(int id, int value);
    // void SetCustomerBalance(int id, int value);
    
    // ------------------- Staff ------------------- //
    // int GetStaffId();
    void SetStaffId(int userId, int value);
    
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