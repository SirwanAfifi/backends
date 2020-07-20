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
            var a = MyClosure();
            Console.WriteLine(a(10));
            Console.WriteLine(a(10));
            Console.WriteLine(a(10));
        }

        static Func<int> CreateCounter()
        {
            var num = 0;
            return () => num++;
        }

        static Func<int, int> MyClosure()
        {
            int val = 0;
            return (int input) =>
            {
                return val += input;
            };
        }
    }
}
