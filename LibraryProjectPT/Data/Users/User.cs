namespace Data.Users;
public abstract class User
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public long Phone { get; set; }

    public User(string surname, string name, long phone)
    {
        Surname = surname;
        Name = name;
        Phone = phone;
    }

    // public string GetSurname();
    // public string GetName();
    // public int GetPhone();
    // public void SetSurname(string value);
    // public void SetName(string value);
    // public void SetPhone(int value);
}