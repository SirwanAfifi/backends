using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace fp
{
    class Program
    {
        private static IList<int> numbers = Enumerable.Range(1, 20).ToList();
        private static Func<int, int> Adder = x => x += value;
        static void Main(string[] args)
        {
            IncrementValue();
            IncrementValue();
            IncrementValue();
            DisplayValue();
            DecrementValue();
            DecrementValue();
            DisplayValue();
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

        // Managing value
        private static int value = 5;
        static Action IncrementValue = () => value++;
        static Action DecrementValue = () => value--;
        static Action DisplayValue = () => Console.WriteLine(value);
    }
}
