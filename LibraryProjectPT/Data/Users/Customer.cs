namespace Data.Users;
public class Customer : User
{
    public int CustomerId { get; set; }
    public int Balance { get; set; }

    public Customer(int customerId, string surname, string name, long phone)
        : base(surname, name, phone)
    {
        CustomerId = customerId;
    }

    // public int GetCustomerId();
    // public int GetBalance();
    // public void SetCustomerId(int value);
    // public void SetBalance(int value);
}