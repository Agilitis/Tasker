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

        //Given a todo with an updated priority the method should update all the other tasks' priorities
        IList<Todo> UpdateTaskPriorities(Todo todo);
    }
}