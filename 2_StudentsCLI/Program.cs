using System;
using System.Collections.Generic;

var students = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
var courses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
var courseToStudents = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

var addStudentCmd = new AddStudentCommand();
var addCourseCmd = new AddCourseCommand();
var enrollCmd = new EnrollCommand();
var listCmd = new ListStudentsOnCourseCommand();

Console.WriteLine("Campus CLI (step 2). Type 'exit' to quit.");

while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line))
    {
        continue;
    }

    var arguments = SplitArgs(line);
    if (arguments.Length == 0)
    {
        continue;
    }

    var cmd = arguments[0].ToLowerInvariant();

    if (cmd == "exit")
    {
        break;
    }

    else if (cmd == "add-student")
    {
        if (arguments.Length < 3)
        {
            Console.WriteLine("ERR usage: add-student <id> \"<name>\"");
            continue;
        }
        addStudentCmd.Execute(students, arguments[1], arguments[2]);
        Console.WriteLine("OK");
    }
    else if (cmd == "add-course")
    {
        if (arguments.Length < 3)
        {
            Console.WriteLine("ERR usage: add-course <code> \"<title>\"");
            continue;
        }
        addCourseCmd.Execute(courses, arguments[1], arguments[2]);
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

        var before = courseToStudents.ContainsKey(courseCode) && courseToStudents[courseCode].Contains(studentId);
        enrollCmd.Execute(students, courses, courseToStudents, studentId, courseCode);

        if (!before) Console.WriteLine("OK");
        else Console.WriteLine("WARN already enrolled");
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
        listCmd.Execute(students, courses, courseToStudents, courseCode);
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
        else current += ch;
    }
    if (current.Length > 0) res.Add(current);
    return res.ToArray();
}