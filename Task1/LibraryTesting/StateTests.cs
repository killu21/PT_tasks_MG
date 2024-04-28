namespace LibraryTests;

[TestFixture]
public class StateTests
{
    private State _state;
    private Library.Library _library;
    private User _user;
    private Book _book;

    [SetUp]
    public void SetUp()
    {
        _library = new Library.Library();
        _user = new Customer("Doe", "John", 1234567890, 1, 100);
        _book = new Book(1, "Book1", "Author1", 30);
        _library.AddUser(_user);
        _library.AddBook(_book);
        _state = new State(_library);
    }

    [Test]
    public void SetCurrentCatalog_ShouldSetCurrentCatalog()
    {
        // Arrange
        var newCatalog = new Catalog();
        var newBook = new Book(2, "Book2", "Author2", 30);
        newCatalog.AddBook(newBook);

        // Act
        _state.SetCurrentCatalog(newCatalog);

        // Assert
        Assert.That(_state.GetCurrentCatalog().GetBooks(), Does.Contain(newBook));
    }

    [Test]
    public void SetCurrentUsers_ShouldSetCurrentUsers()
    {
        // Arrange
        var newUsers = new List<User>();
        User newUser = new Customer("Smith", "Jane", 0987654321, 2, 200);
        newUsers.Add(newUser);

        // Act
        _state.SetCurrentUsers(newUsers);

        // Assert
        Assert.That(_state.GetCurrentUsers(), Does.Contain(newUser));
    }
}