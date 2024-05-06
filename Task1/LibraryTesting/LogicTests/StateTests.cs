using Library.Data;
using Library.Logic;

namespace LibraryTests.LogicTests
{
    [TestFixture]
    public class StateTests
    {
        private IDataInterfaces.ICatalog _catalog;
        private List<IDataInterfaces.IUser> _users;
        private List<Rental> _rentals;
        private State _state;
        private Library.Logic.DataContext.Library _library;
        private User _user;
        private Book _book;

        [SetUp]
        public void SetUp()
        {
            _catalog = new Catalog();
            _users = new List<IDataInterfaces.IUser>();
            _rentals = new List<Rental>();
            _library = new Library.Logic.DataContext.Library(_catalog, _users, _rentals);
            _user = new Customer("Doe", "John", 1234567890,  100);
            _book = new Book( "Book1", "Author1", true);
            _library.AddUser(_user);
            _library.AddBookToCatalog(_book);
            _state = new State(_library);
        }

        [Test]
        public void SetCurrentCatalog_ShouldSetCurrentCatalog()
        {
            // Arrange
            var newCatalog = new Catalog();
            var newBook = new Book("Book2", "Author2", true);
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
            var newUsers = new List<IDataInterfaces.IUser>();
            User newUser = new Customer("Smith", "Jane", 0987654321,  200);
            newUsers.Add(newUser);

            // Act
            _state.SetCurrentUsers(newUsers);

            // Assert
            Assert.That(_state.GetCurrentUsers(), Does.Contain(newUser));
        }
    }
}
