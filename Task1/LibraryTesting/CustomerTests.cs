namespace LibraryTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer("Doe", "John", 1234567890, 1, 100);
        }

        [Test]
        public void GetCustomerId_ShouldReturnCorrectId()
        {
            // Act
            int id = _customer.GetCustomerId();

            // Assert
            Assert.AreEqual(1, id);
        }

        [Test]
        public void SetCustomerId_ShouldUpdateId()
        {
            // Arrange
            int newId = 2;

            // Act
            _customer.SetCustomerId(newId);

            // Assert
            Assert.AreEqual(newId, _customer.GetCustomerId());
        }

        [Test]
        public void GetBalance_ShouldReturnCorrectBalance()
        {
            // Act
            int balance = _customer.GetBalance();

            // Assert
            Assert.AreEqual(100, balance);
        }

        [Test]
        public void SetBalance_ShouldUpdateBalance()
        {
            // Arrange
            int newBalance = 200;

            // Act
            _customer.SetBalance(newBalance);

            // Assert
            Assert.AreEqual(newBalance, _customer.GetBalance());
        }
    }
}