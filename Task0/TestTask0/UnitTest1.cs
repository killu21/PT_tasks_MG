using Calculator;
using NUnit.Framework;
using Task00;

namespace Task00.Tests
{
    [TestFixture]
    public class SumCalculatorTests
    {
        [Test]
        public void Multiplication_Returns_Correct_Result()
        {
            SumCalculator calculator = new SumCalculator();

            int result = calculator.Multiplication(5, 7);

            Assert.AreEqual(35, result);
        }

        [Test]
        public void Multiplication_With_Zero_Returns_Zero()
        {
            SumCalculator calculator = new SumCalculator();

            int result = calculator.Multiplication(5, 0);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Multiplication_With_Negative_Numbers_Returns_Correct_Result()
        {
            SumCalculator calculator = new SumCalculator();

            int result = calculator.Multiplication(-5, 7);

            Assert.AreEqual(-35, result);
        }
    }
}