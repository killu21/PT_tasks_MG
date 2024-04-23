namespace LibraryTests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library.Library _library;
        private User _user;
        private Book _book;

        [SetUp]
        public void SetUp()
        {
            _library = new Library.Library(2000);
            _user = new Customer("Doe", "John", 1234567890, 1, 100);
            _book = new Book(1, "Book1", "Author1", 30);
        }

        [Test]
        public void AddUser_WithValidUser_ShouldAddUser()
        {
            // Act
            _library.AddUser(_user);

            // Assert
            Assert.IsTrue(_library.GetUsers().Contains(_user));
        }

        [Test]
        public void DeleteUser_WithValidUser_ShouldDeleteUser()
        {
            // Arrange
            _library.AddUser(_user);

            // Act
            _library.DeleteUser(_user);

            // Assert
            Assert.IsFalse(_library.GetUsers().Contains(_user));
        }

        [Test]
        public void AddBook_WithValidBook_ShouldAddBook()
        {
            // Act
            _library.AddBook(_book);

            // Assert
            Assert.IsTrue(_library.GetCatalog().GetBooks().Contains(_book));
        }

        [Test]
        public void DeleteBook_WithValidBook_ShouldDeleteBook()
        {
            // Arrange
            _library.AddBook(_book);

            // Act
            _library.DeleteBook(_book);

            // Assert
            Assert.IsFalse(_library.GetCatalog().GetBooks().Contains(_book));
        }

        [Test]
        public void RentBook_WithValidBookAndUser_ShouldRentBook()
        {
            // Arrange
            DateTime rentalDate = DateTime.Now;
            DateTime dueDate = DateTime.Now.AddDays(30);
            _library.AddBook(_book);
            _library.AddUser(_user);

            // Act
            _library.RentBook(_book, _user, rentalDate, dueDate);

            // Assert
            Assert.IsTrue(_library.IsBookRented(_book));
        }

        [Test]
        public void ReturnBook_WithValidBook_ShouldReturnBook()
        {
            // Arrange
            DateTime rentalDate = DateTime.Now;
            DateTime dueDate = DateTime.Now.AddDays(30);
            _library.AddBook(_book);
            _library.AddUser(_user);
            _library.RentBook(_book, _user, rentalDate, dueDate);

            // Act
            _library.ReturnBook(_book);

            // Assert
            Assert.IsFalse(_library.IsBookRented(_book));
        }
    }
}