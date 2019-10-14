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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public Todo Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Todo> UpdateTaskPriorities(Todo todo)
        {
            throw new System.NotImplementedException();
        }
    }
}