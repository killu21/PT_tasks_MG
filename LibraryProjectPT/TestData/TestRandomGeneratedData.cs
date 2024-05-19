using Data;
using DataTest.TestGenerators;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DataTest
{
    [TestClass]
    public class TestRandomGeneratedData : TestData
    {
        [TestInitialize]
        public override void Initialize()
        {
            IDataGenerator dataGenerator = new RandomDataGenerator();
            _context = dataGenerator.GetDataContext();
            _data = new Data.Data(_context);
        }
    }
}