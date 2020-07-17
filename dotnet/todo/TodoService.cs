using System.Linq;
using System.Collections.Generic;

namespace todo
{
    public class TodoService
    {
        private readonly List<Todo> _todos = new List<Todo>();

        public void AddTodo(Todo item)
        {
            _todos.Add(item);
        }

        public void RemoveTodo(int id)
        {
            var foundTodo = _todos.FirstOrDefault(todo => todo.Id == id);
            _todos.Remove(foundTodo);
        }

        public void ToggleTodo(int id)
        {
            var foundTodo = _todos.FirstOrDefault(todo => todo.Id == id);
            foundTodo.IsCompleted = !foundTodo.IsCompleted;
        }

        public IList<Todo> GetAll()
        {
            return _todos.ToList();
        }
    }
}