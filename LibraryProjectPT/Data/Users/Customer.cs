namespace Data.Users;

public abstract class Customer(int customerId, string surname, string name, int phone, int balance)
    : User(surname, name, phone)
{
    public  int GetCustomerId() { return customerId; }

    public  int GetBalance() { return balance; }

    public  void SetCustomerId(int value) { customerId = value; }

    public  void SetBalance(int value) { balance = value; }
}