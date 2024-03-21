
namespace Calculator
{
    public class SumCalculator
    {
        public int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }
    }

    class Program
    {
        static void Main()
        {
            var calculator = new SumCalculator();
            Console.WriteLine("Enter the first number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int result = calculator.Multiplication(number1, number2);
            Console.WriteLine($"The product of {number1} and {number2} is {result}.");
        }
    }
}