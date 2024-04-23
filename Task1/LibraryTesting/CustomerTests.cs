namespace LibraryTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer customer;

        [SetUp]
        public void SetUp()
        {
            customer = new Customer("Doe", "John", 1234567890, 1, 100);
        }

        [Test]
        public void GetCustomerId_ShouldReturnCorrectId()
        {
            // Act
            int id = customer.GetCustomerId();

            // Assert
            Assert.AreEqual(1, id);
        }

        [Test]
        public void SetCustomerId_ShouldUpdateId()
        {
            // Arrange
            int newId = 2;

            // Act
            customer.SetCustomerId(newId);

            // Assert
            Assert.AreEqual(newId, customer.GetCustomerId());
        }

        [Test]
        public void GetBalance_ShouldReturnCorrectBalance()
        {
            // Act
            int balance = customer.GetBalance();

            // Assert
            Assert.AreEqual(100, balance);
        }

        [Test]
        public void SetBalance_ShouldUpdateBalance()
        {
            // Arrange
            int newBalance = 200;

            // Act
            customer.SetBalance(newBalance);

            // Assert
            Assert.AreEqual(newBalance, customer.GetBalance());
        }
    }
}