using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataLayer.TestGenerators;

namespace TestDataLayer;

[TestClass]
public class TestDataRandom : TestData
{
    [TestInitialize]
    public override void Initialize()
    {
        IDataGenerator dataGenerator = new RandomDataGenerator();
        TestRepo = dataGenerator.GetTestRepo();
        Data = new DataLayer.Data(TestRepo);
    }
}