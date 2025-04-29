public class UnitOfWork : IUnitOfWork
{
    private readonly TaskDbContext _context;

    public ITaskRepository TaskRepository { get; }

    public UnitOfWork(TaskDbContext context, ITaskRepository taskRepository)
    {
        _context = context;
        TaskRepository = taskRepository;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
