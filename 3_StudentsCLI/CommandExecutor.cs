// Commands/CommandExecutor.cs
using System;
using System.Collections.Generic;

public sealed class CommandExecutor
{
    private readonly Dictionary<string, ICommand> map =
        new(StringComparer.OrdinalIgnoreCase);

    public void Register(ICommand command) => map[command.Name] = command;

    public bool TryExecute(string[] args, out string? error)
    {
        error = null;
        if (args.Length == 0) { error = "Empty command"; return false; }

        var name = args[0];
        if (!map.TryGetValue(name, out var cmd))
        {
            error = "ERR unknown command";
            return false;
        }

        cmd.Execute(args);
        return true;
    }

    public IEnumerable<ICommand> All => map.Values;
}