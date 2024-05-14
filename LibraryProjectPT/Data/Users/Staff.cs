namespace Data.Users;
public abstract class Staff(int staffId, string surname, string name, int phone)
    : User(surname, name, phone)
{
    public int GetStaffId() { return staffId; }
    
    public void SetStaffId(int value) { staffId = value; }
}