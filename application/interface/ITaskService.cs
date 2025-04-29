public interface ITaskService
{
    Task<IEnumerable<TodoTask>> GetAllAsync();

    Task<TodoTask?> GetByIdAsync(Guid id);

    Task AddAsync(TodoTask task);

    Task DeleteAsync(Guid id);

}