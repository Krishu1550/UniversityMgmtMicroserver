using Microsoft.EntityFrameworkCore;

namespace EnrollCoursesAPI.Repositiory
{
    public class EnrollCourseRepo : IEnrollCourseRepo
    {
        CourseDbContext _db ;

        public EnrollCourseRepo(CourseDbContext courseDbContext)
        {
            _db = courseDbContext;
        }

        public int EnrollCourse(EnrollCourse enrollCourse)
        {
            if(enrollCourse==null)
            {
                return 400;
            }
       
          
               
                StudentCourse studentCourse = new StudentCourse()
                {
                    StudentEmail=enrollCourse.StudentEmail,
                    CouserId = enrollCourse.CourseId
                };
                 _db.StudentCourses.AddAsync(studentCourse);
                 _db.SaveChangesAsync();
                return 200;

    
   

        }

        public IEnumerable<Course> GetEnrolledCourse(string UserEmail)
        {
            if (UserEmail == null)
            {
                return null;
            }
            List<Course> enrollCourses = new List<Course>();
          
       
            List<StudentCourse> studentCourses =  _db.StudentCourses.
            Where(sc => sc.StudentEmail == UserEmail).Include(c=>c.Course).ToList();

            if (studentCourses.Count > 0)
            {
                studentCourses.ForEach(sc => enrollCourses.Add(sc.Course));
                return enrollCourses;
            }
            else
            {
                return null;
            }

        }

        public int UnEnrollCourse(EnrollCourse unenrollCourse)
        {
           StudentCourse studentCourse= _db.StudentCourses.Where(sc=>sc.CouserId==unenrollCourse.CourseId 
           && sc.StudentEmail==unenrollCourse.StudentEmail).FirstOrDefault();

            if(studentCourse == null)
            {
                return 400;
            }
            _db.StudentCourses.Remove(studentCourse);
            _db.SaveChanges();
            return 200;
        }
    }
}
