using NUnit.Framework;
using System;

namespace Task1.Tests
{
    public class EventTests
    {
        [Test]
        public void Event_InitializedCorrectly()
        {
            
            string description = "Test event";
            DateTime time = DateTime.Now;

            Event testEvent = new Event
            {
                Description = description,
                Time = time
            };

            Assert.AreEqual(description, testEvent.Description);
            Assert.AreEqual(time, testEvent.Time);
        }

        [Test]
        public void Event_DefaultConstructor()
        {

            Event testEvent = new Event();

            Assert.IsNotNull(testEvent.Description);
            Assert.AreEqual(default(DateTime), testEvent.Time);
        }

    }
}