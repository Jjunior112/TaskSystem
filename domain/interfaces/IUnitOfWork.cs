public interface IUnitOfWork 
{
    IRepository TaskRepository { get; }

    Task<int> CommitAsync();
}
