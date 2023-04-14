using System;

delegate int MyDelegate(int a, int b, int c);

class Program
{
    static void Main(string[] args)
    {
        MyDelegate average = delegate(int a, int b, int c)
        {
            return (a + b + c) / 3;
        };

        int result = average(3, 6, 9);
        Console.WriteLine("Среднее арифметическое: {0}", result);
    }
}
