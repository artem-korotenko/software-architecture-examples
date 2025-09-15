public sealed class AddStudentCommand
{
    public void Execute(Dictionary<string,string> students, string id, string name)
    {
        students[id] = name;
    }
}