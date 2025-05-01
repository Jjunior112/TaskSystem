using Microsoft.AspNetCore.Mvc;

public interface ITaskService
{
    Task<IEnumerable<TodoTask>> GetAllAsync();

    Task<TodoTask?> GetByIdAsync(Guid id);

    Task<TodoTask> AddAsync(TodoTask task);

    Task UpdateTask(Guid id, [FromBody] UpdateTaskRequest request);

    Task DeleteAsync(Guid id);

}