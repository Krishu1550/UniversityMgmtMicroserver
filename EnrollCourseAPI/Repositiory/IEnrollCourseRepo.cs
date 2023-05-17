namespace EnrollCoursesAPI.Repositiory
{
    public interface IEnrollCourseRepo
    {
        IEnumerable<Course> GetEnrolledCourse( string UserEmail);
         int EnrollCourse(EnrollCourse enrollCourse);
        int UnEnrollCourse(EnrollCourse unenrollCourse);
    }
}
