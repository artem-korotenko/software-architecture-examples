public sealed class EnrollCommand
{
    public void Execute(Dictionary<string,string> students,
        Dictionary<string,string> courses,
        Dictionary<string,List<string>> courseToStudents,
        string studentId, string courseCode)
    {
        if (!courseToStudents.ContainsKey(courseCode))
            courseToStudents[courseCode] = new List<string>();

        var list = courseToStudents[courseCode];
        if (!list.Contains(studentId))
            list.Add(studentId);
    }
}