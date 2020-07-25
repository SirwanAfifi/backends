using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace featherSample
{
    public class HomeController
    {
        public async Task GetTodos(HttpContext http)
        {
            var todos = new Todos();
            await http.Response.WriteJsonAsync(todos.GetAll());
        }
    }
}