using System;

namespace ArithmeticLambda
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<double, double, double> add = (a, b) => a + b;
            Func<double, double, double> sub = (a, b) => a - b;
            Func<double, double, double> mul = (a, b) => a * b;
            Func<double, double, double> div = (a, b) => b != 0 ? a / b : throw new DivideByZeroException("Ділення на нуль!");

            Console.Write("Введіть перше число: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Введіть друге число: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Виберіть дію: ");
            Console.WriteLine("+ - Додати");
            Console.WriteLine("- - Віднять");
            Console.WriteLine("* - Помножити");
            Console.WriteLine("/ - Поділити");
            Console.Write("Ваш выбір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "+":
                    Console.WriteLine($"Результат додавання: {add(num1, num2)}");
                    break;
                case "-":
                    Console.WriteLine($"Результат віднімання: {sub(num1, num2)}");
                    break;
                case "*":
                    Console.WriteLine($"Результат множення: {mul(num1, num2)}");
                    break;
                case "/":
                    try
                    {
                        Console.WriteLine($"Результат ділення: {div(num1, num2)}");
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Вибрана неіснуюча дія.");
                    break;
            }

            Console.ReadLine();
        }
    }
}