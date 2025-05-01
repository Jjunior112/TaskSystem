using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class TaskService : ITaskService
{
    private readonly IUnitOfWork _unitOfWork;

    public TaskService(IUnitOfWork unitOfWork)
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


    public async Task<TodoTask?> AddAsync(TodoTask task)
    {
        var checkTask = await _unitOfWork.TaskRepository.CheckTask(task.TaskName);

        if (!checkTask)
        {
            try
            {
                await _unitOfWork.TaskRepository.AddAsync(task);

                await _unitOfWork.CommitAsync();

                return task;
            }
            catch (Exception)
            {


                throw;
            }

        }
        else
        {
            return null;
        }


    }

    public async Task UpdateTask(Guid id, UpdateTaskRequest request)
    {

        var task = await _unitOfWork.TaskRepository.GetByIdAsync(id);

        if (task != null)
        {
            task.Status = request.status;

            if (task.Status != TaskStatus.Completed)
            {
                task.CompletedAt = null;
            }
            else
            {
                task.CompletedAt = DateTime.Now;
            }

            await _unitOfWork.TaskRepository.UpdateTask(task);

            await _unitOfWork.CommitAsync();
        }



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