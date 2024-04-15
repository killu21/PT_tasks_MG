using NUnit.Framework;

namespace Task1.Tests
{
    public class BookTests
    {
        [Test]
        public void BookConstructor_SetsNameCorrectly()
        {
            string bookName = "The Great Gatsby";

            
            Book book = new Book(bookName);

            Assert.AreEqual(bookName, book.Name);
        }

        [Test]
        public void BookName_IsNotNull()
        {
            string bookName = "To Kill a Mockingbird";

            Book book = new Book(bookName);

            Assert.IsNotNull(book.Name);
        }

        [Test]
        public void BookName_IsNotEmpty()
        {
            string bookName = "Pride and Prejudice";

            Book book = new Book(bookName);

            Assert.IsFalse(string.IsNullOrEmpty(book.Name));
        }
    }
}