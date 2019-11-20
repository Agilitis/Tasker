using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.DataAccessLayer;
using Tasker.Model;


namespace Tasker.Repository
{
    public class TaskerRepository : ITaskerRepository
    {
        private readonly TodoContext _context;


        public TaskerRepository(TodoContext context)
        {
            _context = context;
        }


        public Todo Get(int Id)
        {
            return _context.Todos.Find(Id);
        }

        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos.AsNoTracking();
        }

        public Todo Add(Todo todo)
        {
            var todoWithSamePriority = _context.Todos
                .Where(t => t.Priority == todo.Priority)
                .FirstOrDefault();

            if(todoWithSamePriority != null)
            {
                var todos = _context.Todos
                    .Where(t => t.Priority >= todo.Priority)
                    .ToList();
                foreach (var currentTodo in todos)
                {
                    currentTodo.Priority++;
                }

            }
            _context.Todos.Add(todo);
            return todo;
        }

        public Todo Update(Todo updatedTodo)
        {
            _context.Todos.Update(updatedTodo);
            return updatedTodo;
        }

        public Todo Delete(int Id)
        {
            var todoToDelete = _context.Todos.Find(Id);
            var todos = _context.Todos
                    .Where(t => t.Priority >= todoToDelete.Priority)
                    .ToList();
            foreach (var currentTodo in todos)
            {
                currentTodo.Priority--;
            }
            _context.Todos.Remove(todoToDelete);
            return todoToDelete;
        }

        public IList<Todo> UpdateTaskPriorities(Todo todo)
        {
            throw new System.NotImplementedException();
        }
    }
}