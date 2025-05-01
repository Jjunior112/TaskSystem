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

    public async Task<bool> CheckTask(string taskName)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskName.ToLower().Trim() == taskName.ToLower().Trim());

        if (task != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public async Task AddAsync(TodoTask entity)
    {
        await _context.Tasks.AddAsync(entity);
    }

    public Task UpdateTask(TodoTask task)
    {
        _context.Tasks.Update(task);

        return Task.CompletedTask;
    }
    public Task DeleteAsync(TodoTask task)
    {
        _context.Tasks.Remove(task);

        return Task.CompletedTask;
    }


}