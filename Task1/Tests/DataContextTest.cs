using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Task1.Tests
{
    public class DataContextTests
    {
        [Test]
        public void DataContext_InitializedCorrectly()
        {
            DataContext context = new DataContext();
            
            Assert.IsNotNull(context.Users);
            Assert.IsNotNull(context.Catalog);
            Assert.IsNotNull(context.Rentals);
            Assert.IsNotNull(context.Events);
            Assert.AreEqual(0, context.Users.Count);
            Assert.AreEqual(0, context.Catalog.Count);
            Assert.AreEqual(0, context.Rentals.Count);
            Assert.AreEqual(0, context.Events.Count);
        }

        [Test]
        public void DataContext_CollectionsAreNotNull()
        {
            DataContext context = new DataContext();


            Assert.IsNotNull(context.Users);
            Assert.IsNotNull(context.Catalog);
            Assert.IsNotNull(context.Rentals);
            Assert.IsNotNull(context.Events);
        }

        [Test]
        public void DataContext_CollectionsAreEmpty()
        {
            DataContext context = new DataContext();


            
            Assert.AreEqual(0, context.Users.Count);
            Assert.AreEqual(0, context.Catalog.Count);
            Assert.AreEqual(0, context.Rentals.Count);
            Assert.AreEqual(0, context.Events.Count);
        }

        [Test]
        public void DataContext_CollectionTypesAreCorrect()
        {
            DataContext context = new DataContext();


            Assert.IsInstanceOf<List<User>>(context.Users);
            Assert.IsInstanceOf<Dictionary<int, Book>>(context.Catalog);
            Assert.IsInstanceOf<ObservableCollection<Rental>>(context.Rentals);
            Assert.IsInstanceOf<List<Event>>(context.Events);
        }
    }
}
