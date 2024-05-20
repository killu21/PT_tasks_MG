using DataLayer;
using DataLayer.State;
using DataLayer.Users;

namespace Logic;

public class Library : ILibrary
{
    private readonly IData _data;
    
    public Library(IData data)
    {
        _data = data;
    }

    public void RentBook(int bookId, int customerId, DateTime dueDate)
    {
        if (_data.GetIsBookAvailable(bookId))
        {
            var user = _data.GetUser(customerId);
            if (user is Customer customer)
            {
                var rental = new Rental(Guid.NewGuid(), _data.GetBookFromCatalog(bookId), customer, DateTime.Now, dueDate);
                _data.SetIsBookAvailable(bookId, false);
                _data.AddRental(rental);
            }
            else
            {
                throw new InvalidOperationException("The user is not a customer.");
            }
        }
        else
        {
            throw new InvalidOperationException($"Book '{_data.GetBookTitle(bookId)}' is not available.");
        }
    }

    public void ReturnBook(int bookId)
    {
        if (!_data.GetIsBookAvailable(bookId))
        {
            foreach (var rental in _data.GetRentals())
            {
                if (rental.RentedBook.BookId == bookId)
                {
                    _data.SetIsBookAvailable(bookId, true);
                    _data.RemoveRental(rental);
                }
                else
                {
                    throw new InvalidOperationException($"Book '{_data.GetBookTitle(bookId)}' has no active rental.");
                }
            }
        }
        else
        {
            throw new InvalidOperationException($"Book '{_data.GetBookTitle(bookId)}' is already available.");
        }
    }
}