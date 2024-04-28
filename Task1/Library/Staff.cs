using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Staff : User
{
    private int _staffId;

    public Staff(string surname, string name, int phone, int staffId)
        : base(surname, name, phone)
    {
        _staffId = staffId;
    }

    public int GetStaffId() { return _staffId; }

    public void SetStaffId(int value) { _staffId = value; }
}