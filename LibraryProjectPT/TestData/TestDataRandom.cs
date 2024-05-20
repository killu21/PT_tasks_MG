using DataLayer;
using DataTest.TestGenerators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest;

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