using System;

namespace AnonymousMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Func<int>[] delegates = new Func<int>[]
            {
                () => new Random().Next(1, 10),
                () => new Random().Next(1, 10),
                () => new Random().Next(1, 10)
            };

       
            
            Func<Func<int>[], double> averageDelegate = delegate (Func<int>[] dels)
            {
                double sum = 0;
                foreach (var del in dels)
                {
                    sum += del();
                }
                return sum / dels.Length;
            };

            double result = averageDelegate(delegates);

            Console.WriteLine($"Середнє арифметичне: {result}");
        }
    }
}
