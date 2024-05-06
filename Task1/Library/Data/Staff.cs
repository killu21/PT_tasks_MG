namespace Library.Data;
public abstract class Staff : User, IDataInterfaces.IStaff
{
    private static int _nextStaffId = 1;
    private int _staffId;

    protected Staff(string surname, string name, int phone)
        : base(surname, name, phone)
    {
        _staffId = _nextStaffId;
        _nextStaffId++;
    }

    public int GetStaffId() { return _staffId; }
    
    public static int GetNewStaffId() { return _nextStaffId; }

    public void SetStaffId(int value) { _staffId = value; }
    
    public static void SetNextStaffId(int value) { _nextStaffId = value; }
}