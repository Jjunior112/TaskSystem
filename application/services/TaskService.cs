public class TaskService : ITaskService
{
    private readonly UnitOfWork _unitOfWork;

    public TaskService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<TodoTask>> GetAllAsync()
    {
        return _unitOfWork.TaskRepository.GetAllAsync();
    }

    public Task<TodoTask?> GetByIdAsync(Guid id)
    {
        return _unitOfWork.TaskRepository.GetByIdAsync(id);
    }

    public async Task<TodoTask> AddAsync(AddTaskRequest request)
    {
        var task = new TodoTask(request.taskName, request.status);

        await _unitOfWork.TaskRepository.AddAsync(task);

        await _unitOfWork.CommitAsync();

        return task;
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await _unitOfWork.TaskRepository.GetByIdAsync(id);

        if (task != null)
        {
            await _unitOfWork.TaskRepository.DeleteAsync(task);
        }

        await _unitOfWork.CommitAsync();

    }

}