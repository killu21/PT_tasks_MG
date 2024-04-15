using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_Constructor_Should_Set_Properties()
        {
            string surname = "Doe";
            string name = "John";
            int phone = 123456789;
            string email = "john@example.com";

            User user = new User(surname, name, phone, email);

            Assert.AreEqual(surname, user.GetSurname());
            Assert.AreEqual(name, user.GetName());
            Assert.AreEqual(phone, user.GetPhone());
            Assert.AreEqual(email, user.GetEmail());
        }

        [Test]
        public void User_ToString_Should_Return_Correct_Format()
        {
            string surname = "Doe";
            string name = "John";
            int phone = 123456789;
            string email = "john@example.com";
            User user = new User(surname, name, phone, email);

            string result = user.ToString();

            Assert.AreEqual($"{name} {surname} ({phone})", result);
        }
    }
}