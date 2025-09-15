namespace Commands.Content;

using Tasks;

public class RemoveCommand : InputCommand
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