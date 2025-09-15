using System;
using System.Collections.Generic;

public static class CommandsFactory
{
    public static Context Create()
    {
        var students = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var courses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        var ctx = new Context();

        ctx.Register(new AddStudentDefinition(), new AddStudentHandler(students));
        ctx.Register(new AddCourseDefinition(), new AddCourseHandler(courses));
        
        return ctx;
    }
}