using TestDataLayer.TestGenerators;

namespace TestDataLayer;

[TestFixture]
public class TestDataRandom : TestData
{
    [SetUp]
    public override void Initialize()
    {
        IDataGenerator dataGenerator = new RandomDataGenerator();
        TestRepo = dataGenerator.GetTestRepo();
        Data = new DataLayer.Data(TestRepo);
    }
}