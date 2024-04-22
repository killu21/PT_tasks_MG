using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Staff : User
    {
        private int staffId;
        private int salary;

        public Staff(string surname, string name, int phone, int staffId, int salary)
            : base(surname, name, phone)
        {
            this.staffId = staffId;
            this.salary = salary;
        }

        public int GetStaffId()
        {
            return this.staffId;
        }

        public void SetStaffId(int value)
        {
            this.staffId = value;
        }

        public int GetSalary() { return this.salary; }

        public void SetSalary(int value) {
            this.salary = value;
        }
        
        public void WithdrawMonthlyIncome(Library library)
        {
            double initialFunds = library.GetFunds();
            if (initialFunds >= this.salary)
            {
                initialFunds -= this.salary;
                library.SetFunds(initialFunds);
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds in the library to withdraw monthly income.");
            }
        }
        
        
    }
}