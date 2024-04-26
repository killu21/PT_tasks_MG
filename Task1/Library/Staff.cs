using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Staff : User
{
    private int _staffId;
    private int _salary;

    public Staff(string surname, string name, int phone, int staffId, int salary)
        : base(surname, name, phone)
    {
        _staffId = staffId;
        _salary = salary;
    }

    public int GetStaffId()
    {
        return _staffId;
    }

    public void SetStaffId(int value)
    {
        _staffId = value;
    }

    public int GetSalary() { return _salary; }

    public void SetSalary(int value) {
        _salary = value;
    }
        
    public void WithdrawMonthlyIncome(Library library)
    {
        double initialFunds = library.GetFunds();
        if (initialFunds >= _salary)
        {
            initialFunds -= _salary;
            library.SetFunds(initialFunds);
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds in the library" +
                                                " to withdraw monthly income.");
        }
    }
        
        
}