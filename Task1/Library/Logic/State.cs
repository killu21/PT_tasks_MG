using Library.Data;

namespace Library.Logic;

public class State
{
    private Catalog _currentCatalog;
    private List<User> _currentUsers;
    private DataContext.Library _currentLibrary;

    public State(DataContext.Library library)
    {
        _currentLibrary = library;
        _currentCatalog = library.GetCatalog();
        _currentUsers = library.GetUsers();
    }
    
    public DataContext.Library GetCurrentLibrary()
    {
        return _currentLibrary;
    }

    public Catalog GetCurrentCatalog()
    {
        return _currentCatalog;
    }

    public void SetCurrentCatalog(Catalog catalog)
    {
        _currentCatalog = catalog;
    }

    public List<IDataInterfaces.IUser> GetCurrentUsers()
    {
        return _currentUsers;
    }

    public void SetCurrentUsers(List<User> users)
    {
        _currentUsers = users;
    }
    
    public void SetCurrentLibrary(DataContext.Library library)
    {
        _currentLibrary = library;
    }
}