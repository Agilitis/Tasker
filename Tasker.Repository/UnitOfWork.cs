using Tasker.DataAccessLayer;

namespace Tasker.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;


        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public ITaskerRepository TaskerRepository
        {
            get
            {
                return new TodoRepository(_context);
            }
            set => TaskerRepository = value;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}