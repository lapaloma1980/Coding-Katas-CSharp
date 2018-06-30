using System;

namespace Coding_Katas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int x = 1, y = 2;

            double result = Convert.ToDouble(x/y);
            Console.WriteLine(result);

            result = Convert.ToDouble(x) / Convert.ToDouble(y);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}