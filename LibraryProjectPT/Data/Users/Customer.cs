using Data.Users;

namespace Data.State
{
    public abstract class Customer : User
    {
        private int customerId;
        private int balance;

        public Customer(int customerId, string surname, string name, int phone, int balance)
            : base(surname, name, phone)
        {
            this.customerId = customerId;
            this.balance = balance;
        }

        public abstract int GetCustomerId();
        public abstract int GetBalance();
        public abstract void SetCustomerId(int value);
        public abstract void SetBalance(int value);
    }
}