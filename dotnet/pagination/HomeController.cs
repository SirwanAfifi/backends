using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace pagination
{
    public class HomeController : Controller
    {
        public IActionResult Index(int offset = 0, int limit = 3)
        {
            var fileName = $"employees.txt";
            var path = Path.Combine(  
                Directory.GetCurrentDirectory(), "wwwroot",   
                fileName);  
            var fileBytes = System.IO.File.ReadAllBytes(path);
            
            var result = System.Text.Encoding.UTF8.GetString(fileBytes).Split();

            return Json(result.Skip(limit * (offset - 1))
                .Take(limit));
        }
    }
}