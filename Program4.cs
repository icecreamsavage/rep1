using System;
using System.Collections.Generic;

class Program
{
    delegate int StringLength(string str);

    static void Main()
    {
        List<string> strings = new List<string>()
        {
            "apple",
            "banana",
            "cherry",
            "date",
            "elderberry"
        };
        StringLength lengthDelegate = s => s.Length;

        foreach (string str in strings)
        {
            int length = lengthDelegate(str);
            Console.WriteLine("Длина строки '{0}' равна {1}", str, length);
        }

        Console.ReadLine();
    }
}
