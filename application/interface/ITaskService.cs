public interface ITaskService
{
    Task<IEnumerable<TodoTask>> GetAllAsync();

    Task<TodoTask?> GetByIdAsync(Guid id);

    Task<TodoTask> AddAsync(AddTaskRequest request);

    Task DeleteAsync(Guid id);

}