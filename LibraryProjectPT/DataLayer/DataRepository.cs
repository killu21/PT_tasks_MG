using DataLayer.State;
using DataLayer.Users;

namespace DataLayer;

public class DataRepository
{
    public readonly List<User> UsersList = new List<User>();
    public readonly Catalog BooksCatalog = new Catalog();
    public readonly List<Rental> RentalsList = new List<Rental>();
}