using System;
using System.Collections.Generic;

public class CommandsFactory
{
    public CommandExecutor CreateExecutor()
    {
        var students = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var courses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var courseToStudents = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        var executor = new CommandExecutor();

        executor.Register(new AddStudentCommand(students));
        executor.Register(new AddCourseCommand(courses));
        executor.Register(new EnrollCommand(students, courses, courseToStudents));
        executor.Register(new ListStudentsOnCourseCommand(students, courses, courseToStudents));

        return executor;
    }
}