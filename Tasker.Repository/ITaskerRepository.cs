using System.Collections.Generic;
using Tasker.Model;

namespace Tasker.Repository
{
    public interface ITaskerRepository
    {
        Task GetTaskById(int Id);
        IEnumerable<Task> GetAllTasks();
        Task AddTask(Task task);
        Task UpdateTask(Task updatedTask);
        Task DeleteTaskById(int Id);

        //Given a task with an updated priority the method should update all the other tasks' priorities
        IList<Task> UpdateTaskPriorities(Task task);
    }
}