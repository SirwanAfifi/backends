using System.Collections;
using System.Collections.Generic;

namespace featherSample
{
    public class Todos
    {
        public IList<Todo> GetAll()
        {
            return new List<Todo>
            {
                new Todo { Id = 1, Title = "Read book" },
                new Todo { Id = 2, Title = "Watch an episode of Dark" },
                new Todo { Id = 3, Title = "Publish a post on dotnettips" },
                new Todo { Id = 4, Title = "Skype with my friend" },
                new Todo { Id = 5, Title = "Washing the dishes" },
            };
        }
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}