namespace Commands.Content;

using Tasks;

public class RemoveCommand : Command
{
    private readonly ITaskStorage taskStorage;

    public RemoveCommand(ITaskStorage taskStorage)
    {
        this.taskStorage = taskStorage;
    }

    protected override string CommandName => "remove";


    protected override void Execute(string[] args)
    {
        Console.WriteLine("Removing command");
    }
}