using Microsoft.EntityFrameworkCore;

public class TaskRepository : IRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext taskDbContext)
    {
        _context = taskDbContext;
    }
    public async Task<IEnumerable<TodoTask>> GetAllAsync() => await _context.Tasks.AsNoTracking().ToListAsync();

    public async Task<TodoTask?> GetByIdAsync(Guid id) => await _context.Tasks.Where(t => t.Id == id).FirstOrDefaultAsync();

    public async Task AddAsync(TodoTask entity)
    {
        await _context.Tasks.AddAsync(entity);
    }

    public Task DeleteAsync(TodoTask task)
    {
        _context.Tasks.Remove(task);

        return Task.CompletedTask;
    }


}