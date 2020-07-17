using System;

namespace todo
{
    class Program
    {
        static void Main(string[] args)
        {
            var todoService = new TodoService();
            todoService.AddTodo(new Todo { Id = 1, Title = "Read the Book" });
            todoService.AddTodo(new Todo { Id = 2, Title = "Go to Gym" });
            todoService.AddTodo(new Todo { Id = 3, Title = "Continue working on the hobby project" });

            todoService.ToggleTodo(1);

            var list = todoService.GetAll();
            foreach (Todo item in list)
            {
                Console.WriteLine($"{item.Id} - {item.Title} - {item.IsCompleted}");
            }
        }
    }
}
