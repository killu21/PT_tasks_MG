using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Customer : User
{
    private int _customerId;
    private int _balance;

    public Customer(string surname, string name, int phone, int customerId, int balance) 
        : base(surname, name, phone)
    {
        _customerId = customerId;
        _balance = balance;
    }

    public int GetCustomerId() { return _customerId; }

    public void SetCustomerId(int value) { _customerId = value; }
        
    public int GetBalance() { return _balance; }

    public void SetBalance(int value) { _balance = value; }
}