using Data;

namespace DataTest;

public interface IDataGenerator
{
    public DataRepository GetDataContext();
}