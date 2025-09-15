// Commands/ListStudentsOnCourseCommand.cs
using System;
using System.Collections.Generic;

public sealed class ListStudentsOnCourseCommand(
    Dictionary<string, string> students,
    Dictionary<string, string> courses,
    Dictionary<string, List<string>> courseToStudents)
    : ICommand
{

    public string Name => "list-students-on-course";

    public string Usage => "list-students-on-course <courseCode>";

    public void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine($"ERR usage: {Usage}");
            return;
        }
        var courseCode = args[1];

        if (!courses.ContainsKey(courseCode))
        {
            Console.WriteLine("ERR course not found");
            return;
        }

        if (!courseToStudents.ContainsKey(courseCode) || courseToStudents[courseCode].Count == 0)
        {
            Console.WriteLine($"No students enrolled in {courseCode} ({courses[courseCode]}).");
            return;
        }

        Console.WriteLine($"{courseCode} {courses[courseCode]} — Students:");
        foreach (var sid in courseToStudents[courseCode])
            Console.WriteLine($"  {sid} {students[sid]}");
    }
}