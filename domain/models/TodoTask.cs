public class TodoTask
{
    public TodoTask(string taskName, TaskStatus status)
    {
        Id = Guid.NewGuid();
        TaskName = taskName;
        CreatedAt = DateTime.Now;
        Status = status;
        CompletedAt = null;
    }

    public Guid Id { get; private set; }

    public string TaskName { get; set; }

    public DateTime CreatedAt{get;private set;}

    public TaskStatus Status { get; set; }

    public DateTime? CompletedAt {get;set;}

}