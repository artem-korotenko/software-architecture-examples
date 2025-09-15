public sealed class ListStudentsOnCourseCommand
{
    public void Execute(Dictionary<string,string> students,
        Dictionary<string,string> courses,
        Dictionary<string,List<string>> courseToStudents,
        string courseCode)
    {
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