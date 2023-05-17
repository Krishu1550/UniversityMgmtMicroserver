using Microsoft.AspNetCore.Mvc;


namespace StudentAPI.Repository
{
    public interface IStudentRepo
    {
        //bool SavaChange();
        Student GetProfile(string StudentEmail);
        bool EditProfile( Student student);
        //List<Course> GetEnrolledCourse(string StudentEmail);
        //bool UnEnrollCourse(EnrollCourse enrollcourse);
      



    }
}
