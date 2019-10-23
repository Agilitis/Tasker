using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.DataAccessLayer;
using Tasker.Model;


namespace Tasker.Repository
{
    public class TodoRepository : ITaskerRepository
    {
        private readonly TodoContext _context;


        public TodoRepository(TodoContext context)
        {
            _context = context;
        }


        public Todo Get(int Id)
        {
            return _context.Todos.Find(Id);
        }

        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos.ToList();
        }

        public Todo Add(Todo todo)
        {
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
            _context.Todos.Remove(todoToDelete);
            return todoToDelete;
        }

        public IList<Todo> UpdateTaskPriorities(Todo todo)
        {
            throw new System.NotImplementedException();
        }
    }
}