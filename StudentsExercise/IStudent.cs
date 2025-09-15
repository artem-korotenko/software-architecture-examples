namespace StudentsExercise;

public interface IStudent
{
    Guid Id { get; }
    
    string FullName { get; }

    IReadOnlyCollection<string> EnrolledCourseCodes { get; }
    
    void Enroll(string courseCode);
    
    void Drop(string courseCode);

    void RecordGrade(string courseCode, decimal points);
    
    decimal? GetFinalGrade(string courseCode);

    void AddCharge(decimal amount, string reason);
    
    decimal OutstandingBalance { get; }

    bool CanElectCourses { get; }
    
    string Email { get; }
}

public interface ITeacher
{
    Guid Id { get; }
    
    string FullName { get; }
    
    string Email { get; }
    
    string Department { get; }
}

// and we want to track Auditors too, somehow