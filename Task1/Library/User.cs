using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class User
    {
        private string surname;
        private string name;
        private int phone;

        public User(string surname, string name, int phone)
        {
            this.surname = surname;
            this.name = name;
            this.phone = phone;
        }

        public string GetSurname()
        {
            return this.surname;
        }

        public void SetSurname(string value)
        {
            this.surname = value;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public int GetPhone()
        {
            return this.phone;
        }

        public void SetPhone(int value)
        {
            this.phone = value;
        }
    }
}
