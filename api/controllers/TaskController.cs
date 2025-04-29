using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{

    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]

    public async Task<IActionResult> GetAllAsync() => Ok(await _taskService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var task = await _taskService.GetByIdAsync(id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]

    public async Task<IActionResult> CreateTask(AddTaskRequest request)
    {
        var task = await _taskService.AddAsync(request);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = task.Id }, task);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _taskService.DeleteAsync(id);

        return Ok();
    }

}