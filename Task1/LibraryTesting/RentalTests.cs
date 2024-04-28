namespace LibraryTests
{
    [TestFixture]
    public class RentalTests
    {
        private Rental _rental;
        private Book _book;
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _book = new Book(1, "Book1", "Author1", 30);
            _customer = new Customer("Doe", "John", 1234567890, 1, 100);
            _rental = new Rental(Rental.GetNextRentalId(), _book, _customer, DateTime.Now, DateTime.Now.AddDays(30));
        }

        [Test]
        public void ReturnBook_WhenBookIsNotReturned_ShouldSetIsReturnedToTrue()
        {
            // Act
            _rental.ReturnBook();

            // Assert
            Assert.That(_rental.IsReturned);
        }

        [Test]
        public void ReturnBook_WhenBookIsAlreadyReturned_ShouldThrowInvalidOperationException()
        {
            // Arrange
            _rental.ReturnBook();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _rental.ReturnBook());
        }

        [Test]
        public void IsOverdue_WhenDueDateIsInTheFuture_ShouldReturnFalse()
        {
            // Act
            var isOverdue = _rental.IsOverdue();

            // Assert
            Assert.That(isOverdue, Is.False);
        }

        [Test]
        public void IsOverdue_WhenDueDateIsInThePastAndBookIsNotReturned_ShouldReturnTrue()
        {
            // Arrange
            _rental = new Rental(Rental.GetNextRentalId(), _book, _customer, DateTime.Now.AddDays(-31), DateTime.Now.AddDays(-1));

            // Act
            bool isOverdue = _rental.IsOverdue();

            // Assert
            Assert.That(isOverdue);
        }

        [Test]
        public void ToString_ShouldReturnCorrectString()
        {
            // Act
            string rentalString = _rental.ToString();

            // Assert
            Assert.That(rentalString, Is.EqualTo($"Rental ID: {_rental.RentalId}\nBook Title: {_book.GetTitle()}\n" +
                                                 $"Rented By: {_customer.GetName()}\nRental Status: On Loan\n"));
        }
    }
}