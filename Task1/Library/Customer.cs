using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Customer : User
    {
        private int customerId;
        private int balance;

        public Customer(string surname, string name, int phone, int customerId, int balance)
            : base(surname, name, phone)
        {
            this.customerId = customerId;
            this.balance = balance;
        }

        public int GetCustomerId()
        {
            return this.customerId;
        }

        public void SetCustomerId(int value)
        {
            this.customerId = value;
        }
        
        public int GetBalance() {return this.balance;}

        public void SetBalance(int value) { this.balance = value; }
    }
}