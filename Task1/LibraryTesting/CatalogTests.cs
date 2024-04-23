namespace LibraryTests
{
    [TestFixture]
    public class CatalogTests
    {
        private Catalog _catalog;
        private Book _book1;
        private Book _book2;

        [SetUp]
        public void SetUp()
        {
            _book1 = new Book(1, "Book1", "Author1", 30);
            _book2 = new Book(2, "Book2", "Author2", 30);
            Dictionary<int, Book> initialBooks = new Dictionary<int, Book>
            {
                { _book1.GetId(), _book1 },
                { _book2.GetId(), _book2 }
            };
            _catalog = new Catalog(initialBooks);
        }

        [Test]
        public void AddBook_WithValidBook_ShouldAddBookToCatalog()
        {
            // Arrange
            Book book3 = new Book(3, "Book3", "Author3", 30);

            // Act
            _catalog.AddBook(book3);

            // Assert
            Assert.IsTrue(_catalog.GetBooks().Contains(book3));
        }

        [Test]
        public void RemoveBook_WithValidBook_ShouldRemoveBookFromCatalog()
        {
            // Act
            _catalog.RemoveBook(_book1);

            // Assert
            Assert.IsFalse(_catalog.GetBooks().Contains(_book1));
        }

        [Test]
        public void GetBooks_ShouldReturnAllBooksInCatalog()
        {
            // Act
            List<Book> books = _catalog.GetBooks();

            // Assert
            Assert.Contains(_book1, books);
            Assert.Contains(_book2, books);
        }
    }
}