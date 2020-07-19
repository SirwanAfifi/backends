using System;

namespace fp
{
    class Program
    {
        static void Main(string[] args)
        {
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
