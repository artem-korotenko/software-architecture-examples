

public sealed class CommandsLoop(CommandExecutor executor)
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
                foreach (ICommand c in executor.All)
                {
                    Console.WriteLine($"{c.Name} — {c.Usage}");
                }
                continue;
            }

            if (!executor.TryExecute(args, out string error) && error != null)
            {
                Console.WriteLine(error);
            }
        }
    }

    private static string[] SplitArgs(string input)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string current = "";

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
