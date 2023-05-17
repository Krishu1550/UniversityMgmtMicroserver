

using Microsoft.AspNetCore.Mvc;


    public interface ICourseRepo
    {
       Task< bool> SavaChange();
       Task< IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<int> CreateCourse(Course course);
        Task<int> UpdateCourse(Course course);
        Task<int> DeleteCourse(int id);  
    }

