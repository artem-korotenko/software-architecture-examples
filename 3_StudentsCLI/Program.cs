
var students = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
var courses  = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
var courseToStudents = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

var exec = new CommandExecutor();
exec.Register(new AddStudentCommand(students));
exec.Register(new AddCourseCommand(courses));
exec.Register(new EnrollCommand(students, courses, courseToStudents));
exec.Register(new ListStudentsOnCourseCommand(students, courses, courseToStudents));

Console.WriteLine("Campus CLI (3 step). Type 'exit' to quit. Try 'help' for list.");
while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line)) continue;

    var arguments = SplitArgs(line);
    if (arguments.Length == 0) continue;

    if (arguments[0].Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    if (arguments[0].Equals("help", StringComparison.OrdinalIgnoreCase))
    {
        foreach (var c in exec.All)
        {
            Console.WriteLine($"{c.Name} — {c.Usage}");
        }
        continue;
    }

    if (!exec.TryExecute(arguments, out var err) && err != null)
    {
        Console.WriteLine(err);
    }
}

static string[] SplitArgs(string input)
{
    var res = new List<string>();
    bool inQ = false; var cur = "";
    foreach (var ch in input.Trim())
    {
        if (ch == '"') { inQ = !inQ; continue; }
        if (!inQ && char.IsWhiteSpace(ch)) { if (cur.Length > 0) { res.Add(cur); cur = ""; } }
        else cur += ch;
    }
    if (cur.Length > 0) res.Add(cur);
    return res.ToArray();
}