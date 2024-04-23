namespace LibraryTests
{
    [TestFixture]
    public class StaffTests
    {
        private Staff staff;
        private Library.Library library;

        [SetUp]
        public void SetUp()
        {
            staff = new Staff("Doe", "John", 1234567890, 1, 1000);
            library = new Library.Library(2000);
        }

        [Test]
        public void GetStaffId_ShouldReturnCorrectId()
        {
            // Act
            int id = staff.GetStaffId();

            // Assert
            Assert.AreEqual(1, id);
        }

        [Test]
        public void SetStaffId_ShouldUpdateId()
        {
            // Arrange
            int newId = 2;

            // Act
            staff.SetStaffId(newId);

            // Assert
            Assert.AreEqual(newId, staff.GetStaffId());
        }

        [Test]
        public void GetSalary_ShouldReturnCorrectSalary()
        {
            // Act
            int salary = staff.GetSalary();

            // Assert
            Assert.AreEqual(1000, salary);
        }

        [Test]
        public void SetSalary_ShouldUpdateSalary()
        {
            // Arrange
            int newSalary = 2000;

            // Act
            staff.SetSalary(newSalary);

            // Assert
            Assert.AreEqual(newSalary, staff.GetSalary());
        }

        [Test]
        public void WithdrawMonthlyIncome_WhenFundsAreSufficient_ShouldDecreaseLibraryFunds()
        {
            // Arrange
            double initialFunds = library.GetFunds();

            // Act
            staff.WithdrawMonthlyIncome(library);

            // Assert
            Assert.AreEqual(initialFunds - staff.GetSalary(), library.GetFunds());
        }

        [Test]
        public void WithdrawMonthlyIncome_WhenFundsAreInsufficient_ShouldThrowInvalidOperationException()
        {
            // Arrange
            library.SetFunds(staff.GetSalary() - 1);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => staff.WithdrawMonthlyIncome(library));
        }
    }
}