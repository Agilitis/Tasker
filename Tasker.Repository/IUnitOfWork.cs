namespace Tasker.Repository
{
    public interface IUnitOfWork
    {
        ITaskerRepository TaskerRepository { get; set; }
        void Save();
    }
}