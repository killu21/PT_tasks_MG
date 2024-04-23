using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Customer : User
    {
        private int _customerId;
        private int _balance;

        public Customer(string surname, string name, int phone, int customerId, int balance)
            : base(surname, name, phone)
        {
            this._customerId = customerId;
            this._balance = balance;
        }

        public int GetCustomerId()
        {
            return this._customerId;
        }

        public void SetCustomerId(int value)
        {
            this._customerId = value;
        }
        
        public int GetBalance() {return this._balance;}

        public void SetBalance(int value) { this._balance = value; }
    }
}