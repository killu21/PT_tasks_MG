namespace LibraryTests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library.Library library;
        private User user;
        private Book book;

        [SetUp]
        public void SetUp()
        {
            library = new Library.Library(2000);
            user = new Customer("Doe", "John", 1234567890, 1, 100);
            book = new Book(1, "Book1", "Author1", 30);
        }

        [Test]
        public void AddUser_WithValidUser_ShouldAddUser()
        {
            // Act
            library.AddUser(user);

            // Assert
            Assert.IsTrue(library.GetUsers().Contains(user));
        }

        [Test]
        public void DeleteUser_WithValidUser_ShouldDeleteUser()
        {
            // Arrange
            library.AddUser(user);

            // Act
            library.DeleteUser(user);

            // Assert
            Assert.IsFalse(library.GetUsers().Contains(user));
        }

        [Test]
        public void AddBook_WithValidBook_ShouldAddBook()
        {
            // Act
            library.AddBook(book);

            // Assert
            Assert.IsTrue(library.GetCatalog().GetBooks().Contains(book));
        }

        [Test]
        public void DeleteBook_WithValidBook_ShouldDeleteBook()
        {
            // Arrange
            library.AddBook(book);

            // Act
            library.DeleteBook(book);

            // Assert
            Assert.IsFalse(library.GetCatalog().GetBooks().Contains(book));
        }

        [Test]
        public void RentBook_WithValidBookAndUser_ShouldRentBook()
        {
            // Arrange
            DateTime rentalDate = DateTime.Now;
            DateTime dueDate = DateTime.Now.AddDays(30);
            library.AddBook(book);
            library.AddUser(user);

            // Act
            library.RentBook(book, user, rentalDate, dueDate);

            // Assert
            Assert.IsTrue(library.IsBookRented(book));
        }

        [Test]
        public void ReturnBook_WithValidBook_ShouldReturnBook()
        {
            // Arrange
            DateTime rentalDate = DateTime.Now;
            DateTime dueDate = DateTime.Now.AddDays(30);
            library.AddBook(book);
            library.AddUser(user);
            library.RentBook(book, user, rentalDate, dueDate);

            // Act
            library.ReturnBook(book);

            // Assert
            Assert.IsFalse(library.IsBookRented(book));
        }
    }
}