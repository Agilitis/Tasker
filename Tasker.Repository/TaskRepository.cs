using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.DataAccessLayer;
using Task = Tasker.Model.Task;

namespace Tasker.Repository
{
    public class TaskRepository : ITaskerRepository
    {
        private readonly TaskerContext _context;


        public TaskRepository(TaskerContext context)
        {
            _context = context;
        }


        public Task GetTaskById(int Id)
        {
           return _context.Tasks.Find(Id);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Tasks;
        }

        public Task AddTask(Task task)
        {
            _context.Tasks.Add(task);
            return task;
        }

        public Task UpdateTask(Task updatedTask)
        {
            //TODO check if updateTask exists in database
            _context.Tasks.Update(updatedTask);
            return updatedTask;
        }

        public Task DeleteTaskById(int Id)
        {
            var taskToDelete = this.GetTaskById(Id);
            _context.Tasks.Remove(taskToDelete);
            return taskToDelete;
        }

        public IList<Task> UpdateTaskPriorities(Task task)
        {
            throw new System.NotImplementedException();
        }
    }
}