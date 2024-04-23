namespace LibraryTests
{
    [TestFixture]
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new Customer("Doe", "John", 1234567890, 1, 100);
        }

        [Test]
        public void GetSurname_ShouldReturnCorrectSurname()
        {
            // Act
            string surname = _user.GetSurname();

            // Assert
            Assert.AreEqual("Doe", surname);
        }

        [Test]
        public void SetSurname_ShouldUpdateSurname()
        {
            // Arrange
            string newSurname = "Smith";

            // Act
            _user.SetSurname(newSurname);

            // Assert
            Assert.AreEqual(newSurname, _user.GetSurname());
        }

        [Test]
        public void GetName_ShouldReturnCorrectName()
        {
            // Act
            string name = _user.GetName();

            // Assert
            Assert.AreEqual("John", name);
        }

        [Test]
        public void SetName_ShouldUpdateName()
        {
            // Arrange
            string newName = "Jane";

            // Act
            _user.SetName(newName);

            // Assert
            Assert.AreEqual(newName, _user.GetName());
        }

        [Test]
        public void GetPhone_ShouldReturnCorrectPhone()
        {
            // Act
            int phone = _user.GetPhone();

            // Assert
            Assert.AreEqual(1234567890, phone);
        }

        [Test]
        public void SetPhone_ShouldUpdatePhone()
        {
            // Arrange
            int newPhone = 987654321;

            // Act
            _user.SetPhone(newPhone);

            // Assert
            Assert.AreEqual(newPhone, _user.GetPhone());
        }
    }
}