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
            var todoWithSamePriority = _context.Todos
                .Where(t => t.Priority == updatedTodo.Priority)
                .FirstOrDefault();

            if (updatedTodo.Id == todoWithSamePriority?.Id)
            {
                todoWithSamePriority.State = updatedTodo.State;
                _context.Todos.Update(todoWithSamePriority);
                return updatedTodo;
            }
            var oldTodo = Get(updatedTodo.Id);
            if (todoWithSamePriority != null)
            {
                var priority = todoWithSamePriority.Priority;
                todoWithSamePriority.Priority = oldTodo.Priority;
                oldTodo.Priority = priority;
            }
            return updatedTodo;
        }

        public void Delete(int id)
        {
            var todoToDelete = _context.Todos.Find(id);
            if(todoToDelete == null)
            {
                return;
            }
            var todos = _context.Todos
                    .Where(t => t.Priority >= todoToDelete.Priority)
                    .ToList();
            foreach (var currentTodo in todos)
            {
                currentTodo.Priority--;
            }
            _context.Todos.Remove(todoToDelete);
        }

    }
}