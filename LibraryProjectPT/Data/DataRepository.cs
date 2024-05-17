using Data.State;
using Data.Users;

namespace Data;
public class DataRepository
{
    public List<User> UsersList = new List<User>();
    public Catalog BooksCatalog = new Catalog();
    public List<Rental> RentalsList = new List<Rental>();
}