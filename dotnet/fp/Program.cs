using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace fp
{
    class Program
    {
        private static IList<int> numbers = Enumerable.Range(1, 20).ToList();
        private static int value = 5;
        private static Func<int, int> Adder = x => x += value;
        static void Main(string[] args)
        {
            var result = numbers.Sum(Adder);
            Console.WriteLine(result);

            var counter = CreateCounter();
            var num1 = counter();
            var num2 = counter();
            var num3 = counter();
            System.Console.WriteLine(num3);
        }

        static Func<int> CreateCounter()
        {
            var num = 0;
            return () => num++;
        }
    }
}
