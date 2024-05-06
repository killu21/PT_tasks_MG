namespace Library.Data;
public interface IDataInterfaces
{
    public interface IBook
    {
        int GetId();
        string GetTitle();
        string GetAuthor();
        bool GetIsAvailable();
        void SetIsAvailable(bool value);
    }

    public interface IUser
    {
        string GetSurname();
        void SetSurname(string value);
        string GetName();
        void SetName(string value);
        int GetPhone();
        void SetPhone(int value);
    }

    public interface ICustomer : IUser
    {
        int GetCustomerId();
        int GetBalance();
        void SetCustomerId(int value);
        void SetBalance(int value);
    }

    public interface IStaff : IUser
    {
        int GetStaffId();
        void SetStaffId(int value);
    }

    public interface ICatalog
    {
        void AddBook(IBook book);
        void RemoveBook(IBook book);
        List<IBook> GetBooks();
    }
}