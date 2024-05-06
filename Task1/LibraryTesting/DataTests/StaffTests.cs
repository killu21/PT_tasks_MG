using Library.Data;

namespace LibraryTests.DataTests;

[TestFixture]
public class StaffTests
{
    private Staff _staff;
    private Library.Logic.DataContext.Library _library;

    [SetUp]
    public void SetUp()
    {
        _staff = new Staff("Doe", "John", 1234567890);
        _library = new Library.Logic.DataContext.Library();
    }

    [Test]
    public void GetStaffId_ShouldReturnCorrectId()
    {
        // Act
        var id = _staff.GetStaffId();

        // Assert
        Assert.That(id, Is.EqualTo(1));
    }

    [Test]
    public void SetStaffId_ShouldUpdateId()
    {
        // Arrange
        const int newId = 2;

        // Act
        _staff.SetStaffId(newId);

        // Assert
        Assert.That(_staff.GetStaffId(), Is.EqualTo(newId));
    }
}    