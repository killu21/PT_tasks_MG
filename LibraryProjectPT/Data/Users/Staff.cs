using Data.Users;

namespace Data.State
{
    public abstract class Staff : User
    {
        private int staffId;

        public Staff(int staffId, string surname, string name, int phone)
            : base(surname, name, phone)
        {
            this.staffId = staffId;
        }

        public abstract int GetStaffId();
        public abstract void SetStaffId(int value);
    }
}