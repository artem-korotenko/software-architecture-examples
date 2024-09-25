namespace Commands.Content;

using Tasks;

public class ListCommand : Command
{
    private readonly ITaskStorage taskStorage;

    public ListCommand(ITaskStorage taskStorage)
    {
        this.taskStorage = taskStorage;
    }

    protected override string CommandName => "list";

    protected override void Execute(string[] args)
    {
        var all = taskStorage.GetAll();
        for (var index = 0; index < all.Count; index++)
        {
            var task = all[index];
            Console.WriteLine($"{index}) {task.Description}");
        }
    }
}