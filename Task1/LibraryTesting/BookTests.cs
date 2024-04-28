namespace LibraryTests;

[TestFixture]
public class BookTests
{
    [Test]
    public void Book_Constructor_WithValidParameters_ShouldCreateBook()
    {
        // Arrange
        const int bookId = 1;
        const string title = "The Great Gatsby";
        const string author = "F. Scott Fitzgerald";
        const int term = 30;

        // Act
        var book = new Book(bookId, title, author, term);
        Assert.Multiple(() =>
        {

            // Assert
            Assert.That(book.GetId(), Is.EqualTo(bookId));
            Assert.That(book.GetTitle(), Is.EqualTo(title));
            Assert.That(book.GetAuthor(), Is.EqualTo(author));
            Assert.That(book.GetTerm(), Is.EqualTo(term));
        });
    }

    [Test]
    public void SetTerm_WithValidTerm_ShouldUpdateTerm()
    {
        // Arrange
        const int bookId = 1;
        const string title = "The Great Gatsby";
        const string author = "F. Scott Fitzgerald";
        const int term = 30;
        var book = new Book(bookId, title, author, term);

        // Act
        const int newTerm = 60;
        book.SetTerm(newTerm);

        // Assert
        Assert.That(book.GetTerm(), Is.EqualTo(newTerm));
    }

    [Test]
    public void SetTerm_WithInvalidTerm_ShouldThrowArgumentException()
    {
        // Arrange
        const int bookId = 1;
        const string title = "The Great Gatsby";
        const string author = "F. Scott Fitzgerald";
        const int term = 30;
        var book = new Book(bookId, title, author, term);
        Assert.Multiple(() =>
        {
            // Act and Assert
            Assert.That(() => book.SetTerm(0), Throws.ArgumentException);
            Assert.That(() => book.SetTerm(-1), Throws.ArgumentException);
        });
    }
}