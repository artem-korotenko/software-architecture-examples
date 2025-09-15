public sealed class AddCourseCommand
{
    public void Execute(Dictionary<string,string> courses, string code, string title)
    {
        courses[code] = title;
    }
}
