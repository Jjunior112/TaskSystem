public interface IUnitOfWork
{
    IRepository TaskRepository { get; }

    Task CommitAsync();
}