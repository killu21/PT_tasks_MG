using Library.Data;
using Library.Logic;

namespace LibraryTests.LogicTests
{
    [TestFixture]
    public class LibraryTests
    {
        private IDataInterfaces.ICatalog _catalog;
        private List<IDataInterfaces.IUser> _users;
        private List<Rental> _rentals;
        private Library.Logic.DataContext.Library _library;
        private Customer _customer;
        private Book _book;

        [SetUp]
        public void SetUp()
        {
            _catalog = new Catalog();
            _users = new List<IDataInterfaces.IUser>();
            _rentals = new List<Rental>();
            _library = new Library.Logic.DataContext.Library(_catalog, _users, _rentals);
            _customer = new Customer("Doe", "John", 1234567890,  100);
            _book = new Book( "Book1", "Author1", true);
        }

        [Test]
        public void AddUser_WithValidUser_ShouldAddUser()
        {
            // Act
            _library.AddUser(_customer);

            // Assert
            Assert.That(_library.GetUsers(), Does.Contain(_customer));
        }

        [Test]
        public void DeleteUser_WithValidUser_ShouldDeleteUser()
        {
            // Arrange
            _library.AddUser(_customer);

            // Act
            _library.DeleteUser(_customer);

            // Assert
            Assert.That(_library.GetUsers(), Does.Not.Contain(_customer));
        }

        [Test]
        public void AddBook_WithValidBook_ShouldAddBook()
        {
            // Act
            _library.AddBookToCatalog(_book);

            // Assert
            Assert.That(_library.GetCatalog().GetBooks(), Does.Contain(_book));
        }

        [Test]
        public void DeleteBook_WithValidBook_ShouldDeleteBook()
        {
            // Arrange
            _library.AddBookToCatalog(_book);

            // Act
            _library.DeleteBookFromCatalog(_book);

            // Assert
            Assert.That(_library.GetCatalog().GetBooks(), Does.Not.Contain(_book));
        }

        [Test]
        public void RentBook_ShouldRentBook()
        {
            // Arrange
            var rentalDate = DateTime.Now;
            var dueDate = DateTime.Now.AddDays(30);
            _library.AddBookToCatalog(_book);
            _library.AddUser(_customer);

            // Act
            _library.RentBook(_book, _customer, dueDate);

            // Assert
            Assert.That(_library.IsBookRented(_book), Is.True);
        }

        [Test]
        public void ReturnBook_WithValidBook_ShouldReturnBook()
        {
            // Arrange
            DateTime rentalDate = DateTime.Now;
            DateTime dueDate = DateTime.Now.AddDays(30);
            _library.AddBookToCatalog(_book);
            _library.AddUser(_customer);
            _library.RentBook(_book, _customer, dueDate);

            // Act
            _library.ReturnBook(_book);

            // Assert
            Assert.That(_library.IsBookRented(_book), Is.False);
        }
    }
}