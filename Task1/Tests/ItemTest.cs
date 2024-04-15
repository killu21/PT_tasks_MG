using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void Item_Name_Should_Not_Be_Null()
        {
            var item = new MockItem();

            Assert.IsNotNull(item.Name);
        }

        private class MockItem : Item
        {
            public override string Name => "MockName";
        }
    }
}