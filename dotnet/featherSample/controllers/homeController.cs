using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace featherSample
{
    public class HomeController
    {
        private readonly ITodoService _todoService;

        public HomeController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("/")]
        public IList<Todo> HelloWorld() => _todoService.GetAll();
    }
}