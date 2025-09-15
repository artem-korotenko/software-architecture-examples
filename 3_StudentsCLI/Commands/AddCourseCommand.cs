public sealed class AddCourseCommand(Dictionary<string, string> courses) : ICommand
{

    public string Name => "add-course";

    public string Usage => "add-course <code> \"<title>\"";

    public void Execute(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine($"ERR usage: {Usage}");
            return;
        }
        var code = args[1];
        var title = args[2];
        if (string.IsNullOrWhiteSpace(code))
        {
            Console.WriteLine("ERR course code required");
            return;
        }

        courses[code] = title;
        Console.WriteLine("OK");
    }
}