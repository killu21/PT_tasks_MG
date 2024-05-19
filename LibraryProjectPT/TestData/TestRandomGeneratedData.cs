// using Data;
// using DataTest.TestGenerators;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
//
//
// namespace DataTest
// {
//     [TestClass]
//     public class TestRandomGeneratedData : IDataGenerator
//     {
//         [TestInitialize]
//         public override void Initialize()
//         {
//             IDataGenerator dataGenerator = new RandomDataGenerator();
//             _context = dataGenerator.GetDataContext();
//             _data = IData.New(_context); 
//         }
//
//         public DataRepository GetDataContext()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }