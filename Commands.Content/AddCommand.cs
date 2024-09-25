namespace Commands.Content;

using Tasks;

public class AddCommand : Command
{
    private readonly ITaskStorage taskStorage;

    public AddCommand(ITaskStorage taskStorage)
    {
        this.taskStorage = taskStorage;
    }

    protected override string CommandName => "add";

    protected override void Execute(string[] args)
    {
        Console.WriteLine($"Adding command {args[0]}");
        var task = new ToDoTask(string.Join(" ", args));
        taskStorage.AddTask(task);
    }
}