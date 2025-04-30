using Microsoft.AspNetCore.Mvc;

public interface ITaskService
{
    Task<IEnumerable<TodoTask>> GetAllAsync();

    Task<TodoTask?> GetByIdAsync(Guid id);

    Task AddAsync(TodoTask task);

    Task UpdateTask(Guid id, [FromBody] UpdateTaskRequest request);

    Task DeleteAsync(Guid id);

}