namespace LibraryTests;

[TestFixture]
public class UserTests
{
    private User _user;

    [SetUp]
    public void SetUp()
    {
        _user = new Customer("Doe", "John", 1234567890, 100);
    }

    [Test]
    public void GetSurname_ShouldReturnCorrectSurname()
    {
        // Act
        var surname = _user.GetSurname();

        // Assert
        Assert.That(surname, Is.EqualTo("Doe"));
    }

    [Test]
    public void SetSurname_ShouldUpdateSurname()
    {
        // Arrange
        const string newSurname = "Smith";

        // Act
        _user.SetSurname(newSurname);

        // Assert
        Assert.That(_user.GetSurname(), Is.EqualTo(newSurname));
    }

    [Test]
    public void GetName_ShouldReturnCorrectName()
    {
        // Act
        var name = _user.GetName();

        // Assert
        Assert.That(name, Is.EqualTo("John"));
    }

    [Test]
    public void SetName_ShouldUpdateName()
    {
        // Arrange
        const string newName = "Jane";

        // Act
        _user.SetName(newName);

        // Assert
        Assert.That(_user.GetName(), Is.EqualTo(newName));
    }

    [Test]
    public void GetPhone_ShouldReturnCorrectPhone()
    {
        // Act
        var phone = _user.GetPhone();

        // Assert
        Assert.That(phone, Is.EqualTo(1234567890));
    }

    [Test]
    public void SetPhone_ShouldUpdatePhone()
    {
        // Arrange
        const int newPhone = 987654321;

        // Act
        _user.SetPhone(newPhone);

        // Assert
        Assert.That(_user.GetPhone(), Is.EqualTo(newPhone));
    }
}