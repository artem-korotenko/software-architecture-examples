var students = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
var courses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

var ctx = new Context();

ctx.Register(new AddStudentDefinition(), new AddStudentHandler(students));
ctx.Register(new AddCourseDefinition(), new AddCourseHandler(courses));

var loop = new CommandsLoop(ctx);
loop.Run();