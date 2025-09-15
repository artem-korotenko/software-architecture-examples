namespace StudentsExercise;

public interface IEnrollmentService
{
    void Enroll(IStudent student, string courseCode);
    void Drop(IStudent student, string courseCode);
    void EnrollTeacher(ITeacher teacher, string courseCode);
    void DropTeacher(ITeacher teacher, string courseCode);
}

public interface IRosterProvider
{
    IEnumerable<IStudent> GetRoster(string courseCode); 
}

public interface IAttendanceTracker
{
    void MarkPresent(IStudent student, string courseCode, DateOnly date);
    void MarkPresentTeacher(ITeacher teacher, string courseCode, DateOnly date);
}

public interface IGradebook
{
    void RecordGrade(IStudent student, string courseCode, decimal points);
    decimal? GetFinal(IStudent student, string courseCode); 
}

public interface IContractsBilling
{
    void AddCharge(IStudent student, decimal amount, string reason); 
    decimal GetBalance(IStudent student); 
}

public interface ICourseAnnouncements
{
    void SendToStudent(IStudent student, string courseCode, string subject, string body);
    void SendToTeacher(ITeacher teacher, string courseCode, string subject, string body);
}

public interface ICourseMaterials
{
    Stream DownloadFor(IStudent student, string courseCode, string path); 
}

public interface IOfficeHours
{
    void BookStudentSlot(IStudent student, ITeacher teacher, DateTimeOffset start, TimeSpan duration);
    void BlockTeacherSlot(ITeacher teacher, DateTimeOffset start, TimeSpan duration);
    IEnumerable<(DateTimeOffset Start, TimeSpan Duration)> GetStudentBookings(IStudent student, ITeacher teacher);
    IEnumerable<(DateTimeOffset Start, TimeSpan Duration)> GetTeacherBlocks(ITeacher teacher);
}

public interface ILibraryLoans
{
    void Checkout(IStudent student, string isbn); 
    void Return(IStudent student, string isbn); 
    void Checkout(ITeacher teacher, string isbn); 
    void Return(ITeacher teacher, string isbn); 
}


public interface IGrants
{
    void GiveGrant(IStudent student, Guid grantId);
}
