namespace Data.Users
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

        public abstract string GetSurname();
        public abstract string GetName();
        public abstract int GetPhone();
        public abstract void SetSurname(string value);
        public abstract void SetName(string value);
        public abstract void SetPhone(int value);
    }
}