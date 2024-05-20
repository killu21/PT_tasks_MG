namespace DataLayer.Users;
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
}