public class UnitOfWork : IUnitOfWork
{
    private readonly TaskDbContext _context;

    public IRepository TaskRepository { get; }

    public UnitOfWork(TaskDbContext context, IRepository taskRepository)
    {
        _context = context;
        TaskRepository = taskRepository;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    
}
