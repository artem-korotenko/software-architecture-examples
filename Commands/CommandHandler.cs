namespace Commands;

public class CommandHandler
{
    private readonly List<ICommand> commands;

    public CommandHandler(List<ICommand> commands)
    {
        this.commands = commands;
    }

    public void StartListeningToCommands()
    {
        while (true)
        {
            Console.WriteLine("Please, enter new command: ");
            var input = Console.ReadLine();

            var command = commands
                .FirstOrDefault(command => command.TryExecuteInput(input));
        }
    }
}