using System;
using System.Collections.Generic;

public sealed class AddStudentCommand(Dictionary<string, string> students) : ICommand
{

    public string Name => "add-student";

    public string Usage => "add-student <id> \"<name>\"";

    public void Execute(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine($"ERR usage: {Usage}");
            return;
        }
        var id = args[1];
        var name = args[2];
        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("ERR student id required");
            return;
        }

        students[id] = name;
        Console.WriteLine("OK");
    }
}