public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    {
        // Guard Clause 1
        if (student is null)
            throw new ArgumentNullException(nameof(student));

        // Guard Clause 2
        if (course is null)
            throw new ArgumentNullException(nameof(course));

        // Guard Clause 3
        if (course.EnrolledCount >= course.Capacity)
            throw new CapacityReachedException(course.Code);

        // Switch Expression
        string standing = student.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            _ => "Academic Warning"
        };

        Console.WriteLine($"{student.Name} is in {standing}.");

        return new EnrollmentRecord(
            student.Id,
            course.Code,
            DateTime.UtcNow
        );
    }
}