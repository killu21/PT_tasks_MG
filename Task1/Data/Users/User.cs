namespace Data.Users;
public abstract class User(string surname, string name, int phone)
{
    public string GetSurname() { return surname; }

    public void SetSurname(string value) { surname = value; }

    public string GetName() { return name; }

    public void SetName(string value) { name = value; }

    public int GetPhone() { return phone; }

    public void SetPhone(int value) { phone = value; }
}