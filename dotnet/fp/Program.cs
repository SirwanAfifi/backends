using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace fp
{
    public class Program
    {
        private static IList<int> numbers = Enumerable.Range(1, 20).ToList();
        private static Func<int, int> Adder = x => x += value;
        public static async Task Main(string[] args)
        {
            Func<Task<string>> user = GetRandomUser;
            var cached = user.Cache(10);
            Console.WriteLine(await cached());
            Console.WriteLine(await cached());
            Console.WriteLine(await cached());
            Thread.Sleep(10000);
            Console.WriteLine(await cached());
            Console.WriteLine(await cached());
            Console.WriteLine(await cached());
        }

        static async Task<string> GetRandomUser()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://randomuser.me/api/");
                var output = JsonSerializer.Deserialize<
                    Example>(result);
                var user = output.results[0].name;
                return ($"{user.title} - {user.first} - {user.last}");
            }
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

    public class User
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Result
    {
        public User name { get; set; }
    }

    public class Example
    {
        public IList<Result> results { get; set; }
    }

    public static class ClosureHelpers
    {
        public static Func<T> Cache<T>(this Func<T> func, int cacheInterval)
        {
            var cachedValue = func();
            var timeCached = DateTime.Now;

            Func<T> cachedFunc = () =>
            {
                if ((DateTime.Now - timeCached).Seconds >= cacheInterval)
                {
                    timeCached = DateTime.Now;
                    cachedValue = func();
                }
                return cachedValue;
            };

            return cachedFunc;
        }
    }
}
