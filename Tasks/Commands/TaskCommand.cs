namespace Tasks.Commands;

public abstract class TaskCommand
{
    public abstract void Execute();
}

public class AddTaskCommand : TaskCommand
{
    private readonly ITaskStorage taskStorage;

    private string taskDescription;

    public AddTaskCommand(ITaskStorage taskStorage, string taskDescription)
    {
        this.taskStorage = taskStorage;
        this.taskDescription = taskDescription;
    }

    public override void Execute()
    {
        taskStorage.AddTask(new ToDoTask(taskDescription));
    }
}

