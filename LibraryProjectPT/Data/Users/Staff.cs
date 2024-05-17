namespace Data.Users;
public abstract class Staff : User
{
    public int StaffId { get; set; }

    public Staff(int staffId, string surname, string name, int phone)
        : base(surname, name, phone)
    {
        StaffId = staffId;
    }

    // public int GetStaffId();
    // public void SetStaffId(int value);
}