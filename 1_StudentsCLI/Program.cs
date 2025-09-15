var students = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase); // id -> name
var courses  = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase); // code -> title
var courseToStudents = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase); // course -> [studentIds]

Console.WriteLine("Campus CLI (BAD baseline). Type 'exit' to quit.");

while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line)) continue;

    var arguments = SplitArgs(line);
    if (arguments.Length == 0) continue;

    var cmd = arguments[0].ToLowerInvariant();

    if (cmd == "exit")
    {
        break;
    }
    else if (cmd == "add-student")
    {
        // BAD: parsing + validation + execution mixed; no reuse; inconsistent errors
        if (arguments.Length < 3)
        {
            Console.WriteLine("ERR usage: add-student <id> \"<name>\"");
            continue;
        }

        var id = arguments[1];
        var name = arguments[2];

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("ERR student id required");
            continue;
        }

        // duplicates allowed overwrite silently (bad design decision)
        students[id] = name;
        Console.WriteLine("OK");
    }
    else if (cmd == "add-course")
    {
        if (arguments.Length < 3)
        {
            Console.WriteLine("ERR usage: add-course <code> \"<title>\"");
            continue;
        }

        var code = arguments[1];
        var title = arguments[2];

        if (string.IsNullOrWhiteSpace(code))
        {
            Console.WriteLine("ERR course code required");
            continue;
        }

        courses[code] = title;
        // BAD: not initializing courseToStudents here leads to repeated TryAdd checks elsewhere
        Console.WriteLine("OK");
    }
    else if (cmd == "enroll")
    {
        if (arguments.Length < 3)
        {
            Console.WriteLine("ERR usage: enroll <studentId> <courseCode>");
            continue;
        }

        var studentId = arguments[1];
        var courseCode = arguments[2];

        if (!students.ContainsKey(studentId))
        {
            Console.WriteLine("ERR student not found");
            continue;
        }

        if (!courses.ContainsKey(courseCode))
        {
            Console.WriteLine("ERR course not found");
            continue;
        }

        if (!courseToStudents.ContainsKey(courseCode))
        {
            courseToStudents[courseCode] = new List<string>();
        }

        var list = courseToStudents[courseCode];
        if (!list.Contains(studentId))
        {
            list.Add(studentId);
            Console.WriteLine("OK");
        }
        else
        {
            Console.WriteLine("WARN already enrolled");
        }
    }
    else if (cmd == "list-students-on-course")
    {
        if (arguments.Length < 2)
        {
            Console.WriteLine("ERR usage: list-students-on-course <courseCode>");
            continue;
        }

        var courseCode = arguments[1];

        if (!courses.ContainsKey(courseCode))
        {
            Console.WriteLine("ERR course not found");
            continue;
        }

        if (!courseToStudents.ContainsKey(courseCode) || courseToStudents[courseCode].Count == 0)
        {
            Console.WriteLine($"No students enrolled in {courseCode} ({courses[courseCode]}).");
            continue;
        }

        Console.WriteLine($"{courseCode} {courses[courseCode]} — Students:");
        foreach (var sid in courseToStudents[courseCode])
        {
            Console.WriteLine($"  {sid} {students[sid]}");
        }
    }
    else
    {
        Console.WriteLine("ERR unknown command");
    }
}

static string[] SplitArgs(string input)
{
    var res = new List<string>();
    bool inQuotes = false;
    var current = "";

    foreach (var ch in input.Trim())
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
                res.Add(current);
                current = "";
            }
        }
        else
        {
            current += ch;
        }
    }

    if (current.Length > 0) res.Add(current);
    return res.ToArray();
}
