namespace Library.Data;

public abstract class Customer : User, IDataInterfaces.ICustomer
{
    private static int _nextCustomerId = 1;
    private int _customerId;
    private int _balance;

    protected Customer(string surname, string name, int phone, int balance)
        : base(surname, name, phone)
    {
        _customerId = _nextCustomerId;
        _balance = balance;
        _nextCustomerId++;
    }

    public static int GetNextCustomerId() { return _nextCustomerId; }

    public  int GetCustomerId() { return _customerId; }

    public  int GetBalance() { return _balance; }

    public  void SetCustomerId(int value) { _customerId = value; }

    public  void SetBalance(int value) { _balance = value; }

    public static int SetNextCustomerId(int value) { return _nextCustomerId = value; }
}