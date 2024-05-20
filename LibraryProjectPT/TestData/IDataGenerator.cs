using DataLayer;

namespace DataTest;
public interface IDataGenerator
{
    public DataRepository GetTestRepo();
}