using System;

public sealed class CommandsLoop(Context ctx)
{

    public void Run()
    {
        Console.WriteLine("Campus CLI. Type 'exit' to quit. Type 'help' for list.");

        while (true)
        {
            Console.Write("> ");
            string line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] args = SplitArgs(line);

            if (args.Length == 0)
            {
                continue;
            }

            if (args[0].Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (args[0].Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var d in ctx.All)
                {
                    Console.WriteLine($"{d.Name} — {d.Usage}");
                }

                continue;
            }

            if (!ctx.TryHandle(args, out string error) && error != null)
            {
                Console.WriteLine(error);
            }
        }
    }

    private static string[] SplitArgs(string input)
    {
        System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
        var inQuotes = false;
        var current = "";

        foreach (char ch in input.Trim())
        {
            if (ch == '"')
            {
                inQuotes = !inQuotes;
                continue;
            }

            if (!inQuotes && char.IsWhiteSpace(ch))
            {
                if (current.Length > 0)
                {
                    result.Add(current);
                    current = "";
                }
            }
            else
            {
                current += ch;
            }
        }

        if (current.Length > 0)
        {
            result.Add(current);
        }

        return result.ToArray();
    }
}
