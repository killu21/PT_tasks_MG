using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class User
    {
        private string _surname;
        private string _name;
        private int _phone;

        public User(string surname, string name, int phone)
        {
            this._surname = surname;
            this._name = name;
            this._phone = phone;
        }

        public string GetSurname()
        {
            return this._surname;
        }

        public void SetSurname(string value)
        {
            this._surname = value;
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetName(string value)
        {
            this._name = value;
        }

        public int GetPhone()
        {
            return this._phone;
        }

        public void SetPhone(int value)
        {
            this._phone = value;
        }
    }
}
