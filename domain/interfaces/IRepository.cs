public interface IRepository
{
    Task<IEnumerable<TodoTask>> GetAllAsync();

    Task<TodoTask?> GetByIdAsync(Guid Id);

    Task<bool> CheckTask(string taskName);

    Task AddAsync(TodoTask task);

    Task UpdateTask (TodoTask task);


    Task DeleteAsync(TodoTask task);


}