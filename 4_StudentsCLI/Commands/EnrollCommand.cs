using System;
using System.Collections.Generic;

public sealed class EnrollCommand(
    Dictionary<string, string> students,
    Dictionary<string, string> courses,
    Dictionary<string, List<string>> courseToStudents)
    : ICommand
{

    public string Name => "enroll";

    public string Usage => "enroll <studentId> <courseCode>";

    public void Execute(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine($"ERR usage: {Usage}");
            return;
        }
        var studentId = args[1];
        var courseCode = args[2];

        if (!students.ContainsKey(studentId))
        {
            Console.WriteLine("ERR student not found");
            return;
        }
        if (!courses.ContainsKey(courseCode))
        {
            Console.WriteLine("ERR course not found");
            return;
        }

        if (!courseToStudents.ContainsKey(courseCode))
            courseToStudents[courseCode] = new List<string>();

        var list = courseToStudents[courseCode];
        if (!list.Contains(studentId))
        {
            list.Add(studentId);
            Console.WriteLine("OK");
        }
        else Console.WriteLine("WARN already enrolled");
    }
}