public sealed class AddCourseDefinition : ICommandDefinition
{
    public string Name => "add-course";

    public string Usage => "add-course <code> \"<title>\"";

    public bool TryParse(string[] args, out IRequest request, out string error)
    {
        request = null;
        error = null;

        if (args.Length < 3)
        {
            error = $"ERR usage: {Usage}";
            return false;
        }

        string code = args[1];
        string title = args[2];

        if (string.IsNullOrWhiteSpace(code))
        {
            error = "ERR course code required";
            return false;
        }

        request = new AddCourseRequest(code, title);
        return true;
    }
}

public sealed class AddCourseRequest(string code, string title) : IRequest
{
    public string Code { get; } = code;

    public string Title { get; } = title;

}

public sealed class AddCourseHandler(Dictionary<string, string> courses) : IRequestHandler<AddCourseRequest>
{

    public void Handle(AddCourseRequest request)
    {
        courses[request.Code] = request.Title;
        Console.WriteLine("OK");
    }
}