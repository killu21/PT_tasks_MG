namespace LibraryTests
{
    [TestFixture]
    public class StateTests
    {
        private State state;
        private Library.Library library;
        private User user;
        private Book book;

        [SetUp]
        public void SetUp()
        {
            library = new Library.Library(2000);
            user = new Customer("Doe", "John", 1234567890, 1, 100);
            book = new Book(1, "Book1", "Author1", 30);
            library.AddUser(user);
            library.AddBook(book);
            state = new State(library);
        }
        
        [Test]
        public void SetCurrentCatalog_ShouldSetCurrentCatalog()
        {
            // Arrange
            Catalog newCatalog = new Catalog();
            Book newBook = new Book(2, "Book2", "Author2", 30);
            newCatalog.AddBook(newBook);

            // Act
            state.SetCurrentCatalog(newCatalog);

            // Assert
            Assert.IsTrue(state.GetCurrentCatalog().GetBooks().Contains(newBook));
        }
        
        [Test]
        public void SetCurrentUsers_ShouldSetCurrentUsers()
        {
            // Arrange
            List<User> newUsers = new List<User>();
            User newUser = new Customer("Smith", "Jane", 0987654321, 2, 200);
            newUsers.Add(newUser);

            // Act
            state.SetCurrentUsers(newUsers);

            // Assert
            Assert.IsTrue(state.GetCurrentUsers().Contains(newUser));
        }

        [Test]
        public void GetCurrentFunds_ShouldReturnCurrentFunds()
        {
            // Act
            double funds = state.GetCurrentFunds();

            // Assert
            Assert.AreEqual(2000, funds);
        }

        [Test]
        public void SetCurrentFunds_ShouldSetCurrentFunds()
        {
            // Act
            state.SetCurrentFunds(3000);

            // Assert
            Assert.AreEqual(3000, state.GetCurrentFunds());
        }
    }
}