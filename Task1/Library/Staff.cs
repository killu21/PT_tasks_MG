using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Staff : User
    {
        private int _staffId;
        private int _salary;

        public Staff(string surname, string name, int phone, int staffId, int salary)
            : base(surname, name, phone)
        {
            this._staffId = staffId;
            this._salary = salary;
        }

        public int GetStaffId()
        {
            return this._staffId;
        }

        public void SetStaffId(int value)
        {
            this._staffId = value;
        }

        public int GetSalary() { return this._salary; }

        public void SetSalary(int value) {
            this._salary = value;
        }
        
        public void WithdrawMonthlyIncome(Library library)
        {
            double initialFunds = library.GetFunds();
            if (initialFunds >= this._salary)
            {
                initialFunds -= this._salary;
                library.SetFunds(initialFunds);
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds in the library to withdraw monthly income.");
            }
        }
        
        
    }
}