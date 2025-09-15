public sealed class AddStudentDefinition : ICommandDefinition
{
    public string Name => "add-student";

    public string Usage => "add-student <id> \"<name>\"";

    public bool TryParse(string[] args, out IRequest request, out string error)
    {
        request = null;
        error = null;

        if (args.Length < 3)
        {
            error = $"ERR usage: {Usage}";
            return false;
        }

        string id = args[1];
        string name = args[2];

        if (string.IsNullOrWhiteSpace(id))
        {
            error = "ERR student id required";
            return false;
        }

        request = new AddStudentRequest(id, name);
        return true;
    }
}


public sealed class AddStudentRequest(string id, string name) : IRequest
{
    public string Id { get; } = id;

    public string Name { get; } = name;

}

public sealed class AddStudentHandler(Dictionary<string, string> students) : IRequestHandler<AddStudentRequest>
{

    public void Handle(AddStudentRequest request)
    {
        students[request.Id] = request.Name;
        Console.WriteLine("OK");
    }
}