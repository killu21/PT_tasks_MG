using DataLayer;

namespace TestDataLayer;

public interface IDataGenerator
{
    public DataRepository GetTestRepo();
}