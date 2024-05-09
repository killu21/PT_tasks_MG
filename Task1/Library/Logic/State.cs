using Library.Data;

namespace Library.Logic;

public class State
{
    private Catalog _currentCatalog;
    private List<IDataInterfaces.IUser> _currentUsers;
    private Library _currentLibrary;

    public State(Library library)
    {
        _currentLibrary = library;
        _currentCatalog = (Catalog?)library.GetCatalog();
        _currentUsers = library.GetUsers();
    }
    
    public Library GetCurrentLibrary()
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

    public void SetCurrentUsers(List<IDataInterfaces.IUser> users)
    {
        _currentUsers = users;
    }
    
    public void SetCurrentLibrary(Library library)
    {
        _currentLibrary = library;
    }
}