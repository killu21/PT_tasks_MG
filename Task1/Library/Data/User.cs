// Customer and Staff could have different ids c1, c2, s1, s2, etc.
namespace Library.Data;
public abstract class User :  IDataInterfaces.IUser
{
    private string _surname;
    private string _name;
    private int _phone;

    protected User(string surname, string name, int phone)
    {
        _surname = surname;
        _name = name;
        _phone = phone;
    }

    public string GetSurname() { return _surname; }

    public void SetSurname(string value) { _surname = value; }

    public string GetName() { return _name; }

    public void SetName(string value) { _name = value; }

    public int GetPhone() { return _phone; }

    public void SetPhone(int value) { _phone = value; }
}