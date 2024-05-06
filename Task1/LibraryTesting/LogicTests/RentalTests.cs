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
            _book = new Book("Title1", "Author1", true);
            _customer = new Customer("Doe", "John", 1234567890, 100);
            _rental = new Rental(_book, _customer, DateTime.Now.AddDays(30));
        }

        [Test]
        public void Rental_InitializesCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_rental.GetRentedBook(), Is.EqualTo(_book));
                Assert.That(_rental.GetRentedBy(), Is.EqualTo(_customer));
                Assert.That(_book.GetIsAvailable(), Is.False);
            });
        }

        [Test]
        public void ReturnBook_SetsBookAvailabilityToTrue()
        {
            _rental.ReturnBook();
            Assert.That(_book.GetIsAvailable());
        }

        [Test]
        public void ReturnBook_ThrowsExceptionWhenBookAlreadyReturned()
        {
            _rental.ReturnBook();
            Assert.Throws<InvalidOperationException>(() => _rental.ReturnBook());
        }

        [Test]
        public void IsOverdue_ReturnsTrueWhenDueDateIsPast()
        {
            var overdueRental = new Rental(_book, _customer, DateTime.Now.AddDays(-1));
            Assert.That(overdueRental.IsOverdue());
        }
        
        [Test]
        public void IsOverdue_ReturnsFalseWhenDueDateIsFuture()
        {
            Assert.That(_rental.IsOverdue(), Is.False);
        }

        [Test]
        public void ToString_ShouldReturnCorrectString()
        {
            // Act
            var rentalString = _rental.ToString();

            // Assert
            Assert.That(rentalString, Is.EqualTo(
                $"Rental ID: {_rental.GetRentalId()}\n" + $"Book Title: {_book.GetTitle()}\n" + 
                $"Rented By: {_customer.GetName()}\nRental Status: On Loan\n" +
                $"Rental Date: {_rental.GetRentalDate()}\n" +
                $"Due Date: {_rental.GetDueDate()}\"")
            );
        }
    }
}