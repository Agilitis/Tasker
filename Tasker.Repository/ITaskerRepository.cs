using System.Collections.Generic;
using Tasker.Model;

namespace Tasker.Repository
{
    public interface ITaskerRepository
    {
        Todo Get(int Id);
        IEnumerable<Todo> GetAll();
        Todo Add(Todo todo);
        Todo Update(Todo updatedTodo);
        void Delete(int Id);


    }
}