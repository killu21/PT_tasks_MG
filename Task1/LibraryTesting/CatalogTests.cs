namespace LibraryTests
{
    [TestFixture]
    public class CatalogTests
    {
        private Catalog catalog;
        private Book book1;
        private Book book2;

        [SetUp]
        public void SetUp()
        {
            book1 = new Book(1, "Book1", "Author1", 30);
            book2 = new Book(2, "Book2", "Author2", 30);
            Dictionary<int, Book> initialBooks = new Dictionary<int, Book>
            {
                { book1.GetId(), book1 },
                { book2.GetId(), book2 }
            };
            catalog = new Catalog(initialBooks);
        }

        [Test]
        public void AddBook_WithValidBook_ShouldAddBookToCatalog()
        {
            // Arrange
            Book book3 = new Book(3, "Book3", "Author3", 30);

            // Act
            catalog.AddBook(book3);

            // Assert
            Assert.IsTrue(catalog.GetBooks().Contains(book3));
        }

        [Test]
        public void RemoveBook_WithValidBook_ShouldRemoveBookFromCatalog()
        {
            // Act
            catalog.RemoveBook(book1);

            // Assert
            Assert.IsFalse(catalog.GetBooks().Contains(book1));
        }

        [Test]
        public void GetBooks_ShouldReturnAllBooksInCatalog()
        {
            // Act
            List<Book> books = catalog.GetBooks();

            // Assert
            Assert.Contains(book1, books);
            Assert.Contains(book2, books);
        }
    }
}