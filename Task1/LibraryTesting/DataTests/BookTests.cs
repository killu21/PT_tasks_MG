namespace LibraryTests.DataTests;

[TestFixture]
public class BookTests
{
    [Test]
    public void Book_Constructor_WithValidParameters_ShouldCreateBook()
    {
        // Arrange
        const string title = "The Great Gatsby";
        const string author = "F. Scott Fitzgerald";
        const bool available = true;
        const int firstBookId = 1;

        // Act
        var book = new Book(title, author, available);
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(book.GetId(), Is.EqualTo(firstBookId));
            Assert.That(book.GetTitle(), Is.EqualTo(title));
            Assert.That(book.GetAuthor(), Is.EqualTo(author));
            Assert.That(book.GetIsAvailable(), Is.EqualTo(available));
        });
    }
}