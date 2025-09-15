



public sealed class EnrollRequest : IRequest
{
    public string StudentId { get; }
    public string CourseCode { get; }

    public EnrollRequest(string studentId, string courseCode)
    {
        StudentId = studentId;
        CourseCode = courseCode;
    }
}

public sealed class ListStudentsOnCourseRequest : IRequest
{
    public string CourseCode { get; }

    public ListStudentsOnCourseRequest(string courseCode)
    {
        CourseCode = courseCode;
    }
}