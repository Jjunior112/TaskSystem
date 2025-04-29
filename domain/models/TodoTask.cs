public class TodoTask
{
    public TodoTask(string taskName, TaskStatus status)
    {
        Id = Guid.NewGuid();
        TaskName = taskName;
        Status = status;
    }

    public Guid Id { get; private set; }

    public string TaskName { get; set; }

    public TaskStatus Status { get; set; }

}