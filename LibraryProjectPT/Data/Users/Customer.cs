namespace Data.Users;
public abstract class Customer : User
{
    public int CustomerId { get; set; }
    public int Balance { get; set; }

    public Customer(int customerId, string surname, string name, int phone, int balance)
        : base(surname, name, phone)
    {
        CustomerId = customerId;
        Balance = balance;
    }

    // public int GetCustomerId();
    // public int GetBalance();
    // public void SetCustomerId(int value);
    // public void SetBalance(int value);
}