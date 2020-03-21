using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace signalr
{
    [Authorize]
    public class homeController : Controller
    {
        public IActionResult Index()
        {
            return Content("This is a secret page");
        }
    }
}