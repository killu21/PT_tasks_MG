namespace LibraryTests
{
    [TestFixture]
    public class RentalTests
    {
        private Rental rental;
        private Book book;
        private User user;

        [SetUp]
        public void SetUp()
        {
            book = new Book(1, "Book1", "Author1", 30);
            user = new Customer("Doe", "John", 1234567890, 1, 100);
            rental = new Rental(Rental.GetNextRentalId(), book, user, DateTime.Now, DateTime.Now.AddDays(30));
        }

        [Test]
        public void ReturnBook_WhenBookIsNotReturned_ShouldSetIsReturnedToTrue()
        {
            // Act
            rental.ReturnBook();

            // Assert
            Assert.IsTrue(rental.IsReturned);
        }

        [Test]
        public void ReturnBook_WhenBookIsAlreadyReturned_ShouldThrowInvalidOperationException()
        {
            // Arrange
            rental.ReturnBook();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => rental.ReturnBook());
        }

        [Test]
        public void IsOverdue_WhenDueDateIsInTheFuture_ShouldReturnFalse()
        {
            // Act
            bool isOverdue = rental.IsOverdue();

            // Assert
            Assert.IsFalse(isOverdue);
        }

        [Test]
        public void IsOverdue_WhenDueDateIsInThePastAndBookIsNotReturned_ShouldReturnTrue()
        {
            // Arrange
            rental = new Rental(Rental.GetNextRentalId(), book, user, DateTime.Now.AddDays(-31), DateTime.Now.AddDays(-1));

            // Act
            bool isOverdue = rental.IsOverdue();

            // Assert
            Assert.IsTrue(isOverdue);
        }

        [Test]
        public void ToString_ShouldReturnCorrectString()
        {
            // Act
            string rentalString = rental.ToString();

            // Assert
            Assert.AreEqual($"Rental ID: {rental.RentalId}\nBook Title: {book.GetTitle()}\nRented By: {user.GetName()}\nRental Status: On Loan\n", rentalString);
        }
    }
}