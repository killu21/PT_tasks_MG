namespace Library;

public class Staff : User
{
    private static int _nextStaffId = 1;
    private int _staffId;

    public Staff(string surname, string name, int phone)
        : base(surname, name, phone)
    {
        _staffId = _nextStaffId;
        _nextStaffId++;
    }

    public int GetStaffId() { return _staffId; }

    public void SetStaffId(int value) { _staffId = value; }
}