using System;
using System.Collections.Generic;

public sealed class CommandExecutor
{
    private readonly Dictionary<string, ICommand> Map = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase);

    public void Register(ICommand command)
    {
        Map[command.Name] = command;
    }

    public IEnumerable<ICommand> All
    {
        get { return Map.Values; }
    }

    public bool TryExecute(string[] args, out string error)
    {
        error = null;

        if (args.Length == 0)
        {
            error = "Empty command";
            return false;
        }

        string name = args[0];

        if (!Map.TryGetValue(name, out ICommand command))
        {
            error = "ERR unknown command";
            return false;
        }

        command.Execute(args);
        return true;
    }
}