public interface IUnitOfWork : IDisposable
{
    ITaskRepository TaskRepository { get; }

    Task<int> CommitAsync();
}
