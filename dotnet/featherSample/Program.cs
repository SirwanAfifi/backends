using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace featherSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var app = WebApplication.Create(args);

            app.MapGet("/", new HomeController().GetTodos);

            await app.RunAsync();
        }
    }
}
