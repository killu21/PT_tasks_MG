namespace LibraryTests;

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
        var id = _customer.GetCustomerId();

        // Assert
        Assert.That(id, Is.EqualTo(1));
    }

    [Test]
    public void SetCustomerId_ShouldUpdateId()
    {
        // Arrange
        const int newId = 2;

        // Act
        _customer.SetCustomerId(newId);

        // Assert
        Assert.That(_customer.GetCustomerId(), Is.EqualTo(newId));
    }

    [Test]
    public void GetBalance_ShouldReturnCorrectBalance()
    {
        // Act
        var balance = _customer.GetBalance();

        // Assert
        Assert.That(balance, Is.EqualTo(100));
    }

    [Test]
    public void SetBalance_ShouldUpdateBalance()
    {
        // Arrange
        const int newBalance = 200;

        // Act
        _customer.SetBalance(newBalance);

        // Assert
        Assert.That(_customer.GetBalance(), Is.EqualTo(newBalance));
    }
}