using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace pagination
{
    public class HomeController : Controller
    {
        public IActionResult Index(int offset = 0, int limit = 3)
        {
            var names = new[] {"Sirwan", "Kaywan", "Kaveh", "Ali", "Hamed", "Shaho", "Sattar", "Behzad"};
            return Json(names.Skip(limit * (offset - 1))
                .Take(limit));
        }
    }
}