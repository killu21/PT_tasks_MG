namespace DataLayer.Users;

public class Staff : User
{
    public int StaffId { get; set; }

    public Staff(int staffId, string surname, string name, long phone)
        : base(surname, name, phone)
    {
        StaffId = staffId;
    }
}