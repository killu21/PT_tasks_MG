namespace LibraryTests
{
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
            _library = new Library.Library(2000);
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
            Catalog newCatalog = new Catalog();
            Book newBook = new Book(2, "Book2", "Author2", 30);
            newCatalog.AddBook(newBook);

            // Act
            _state.SetCurrentCatalog(newCatalog);

            // Assert
            Assert.IsTrue(_state.GetCurrentCatalog().GetBooks().Contains(newBook));
        }
        
        [Test]
        public void SetCurrentUsers_ShouldSetCurrentUsers()
        {
            // Arrange
            List<User> newUsers = new List<User>();
            User newUser = new Customer("Smith", "Jane", 0987654321, 2, 200);
            newUsers.Add(newUser);

            // Act
            _state.SetCurrentUsers(newUsers);

            // Assert
            Assert.IsTrue(_state.GetCurrentUsers().Contains(newUser));
        }

        [Test]
        public void GetCurrentFunds_ShouldReturnCurrentFunds()
        {
            // Act
            double funds = _state.GetCurrentFunds();

            // Assert
            Assert.AreEqual(2000, funds);
        }

        [Test]
        public void SetCurrentFunds_ShouldSetCurrentFunds()
        {
            // Act
            _state.SetCurrentFunds(3000);

            // Assert
            Assert.AreEqual(3000, _state.GetCurrentFunds());
        }
    }
}