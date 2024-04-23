namespace LibraryTests
{
    [TestFixture]
    public class StaffTests
    {
        private Staff _staff;
        private Library.Library _library;

        [SetUp]
        public void SetUp()
        {
            _staff = new Staff("Doe", "John", 1234567890, 1, 1000);
            _library = new Library.Library(2000);
        }

        [Test]
        public void GetStaffId_ShouldReturnCorrectId()
        {
            // Act
            int id = _staff.GetStaffId();

            // Assert
            Assert.AreEqual(1, id);
        }

        [Test]
        public void SetStaffId_ShouldUpdateId()
        {
            // Arrange
            int newId = 2;

            // Act
            _staff.SetStaffId(newId);

            // Assert
            Assert.AreEqual(newId, _staff.GetStaffId());
        }

        [Test]
        public void GetSalary_ShouldReturnCorrectSalary()
        {
            // Act
            int salary = _staff.GetSalary();

            // Assert
            Assert.AreEqual(1000, salary);
        }

        [Test]
        public void SetSalary_ShouldUpdateSalary()
        {
            // Arrange
            int newSalary = 2000;

            // Act
            _staff.SetSalary(newSalary);

            // Assert
            Assert.AreEqual(newSalary, _staff.GetSalary());
        }

        [Test]
        public void WithdrawMonthlyIncome_WhenFundsAreSufficient_ShouldDecreaseLibraryFunds()
        {
            // Arrange
            double initialFunds = _library.GetFunds();

            // Act
            _staff.WithdrawMonthlyIncome(_library);

            // Assert
            Assert.AreEqual(initialFunds - _staff.GetSalary(), _library.GetFunds());
        }

        [Test]
        public void WithdrawMonthlyIncome_WhenFundsAreInsufficient_ShouldThrowInvalidOperationException()
        {
            // Arrange
            _library.SetFunds(_staff.GetSalary() - 1);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _staff.WithdrawMonthlyIncome(_library));
        }
    }
}