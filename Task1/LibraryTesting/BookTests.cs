namespace LibraryTests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Book_Constructor_WithValidParameters_ShouldCreateBook()
        {
            // Arrange
            int bookId = 1;
            string title = "The Great Gatsby";
            string author = "F. Scott Fitzgerald";
            int term = 30;

            // Act
            Book book = new Book(bookId, title, author, term);

            // Assert
            Assert.AreEqual(bookId, book.GetId());
            Assert.AreEqual(title, book.GetTitle());
            Assert.AreEqual(author, book.GetAuthor());
            Assert.AreEqual(term, book.GetTerm());
        }

        [Test]
        public void SetTerm_WithValidTerm_ShouldUpdateTerm()
        {
            // Arrange
            int bookId = 1;
            string title = "The Great Gatsby";
            string author = "F. Scott Fitzgerald";
            int term = 30;
            Book book = new Book(bookId, title, author, term);

            // Act
            int newTerm = 60;
            book.SetTerm(newTerm);

            // Assert
            Assert.AreEqual(newTerm, book.GetTerm());
        }

        [Test]
        public void SetTerm_WithInvalidTerm_ShouldThrowArgumentException()
        {
            // Arrange
            int bookId = 1;
            string title = "The Great Gatsby";
            string author = "F. Scott Fitzgerald";
            int term = 30;
            Book book = new Book(bookId, title, author, term);

            // Act and Assert
            Assert.That(() => book.SetTerm(0), Throws.ArgumentException);
            Assert.That(() => book.SetTerm(-1), Throws.ArgumentException);
        }
    }
}