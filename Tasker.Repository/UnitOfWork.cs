using Tasker.DataAccessLayer;

namespace Tasker.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskerContext _context;


        public UnitOfWork(TaskerContext context)
        {
            _context = context;
        }

        public ITaskerRepository TaskerRepository
        {
            get
            {
                return new TaskRepository(_context);
            }
            set => TaskerRepository = value;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}