using EnrollCoursesAPI.Database;

namespace EnrollCoursesAPI.Repositiory
{
    public class EnrollCourseRepo : IEnrollCourseRepo
    {
        EnrollCourseDbContext _db ;

        public int EnrollCourse(EnrollCourse enrollCourse)
        {
            Student student = _db.Students.Where(s => s.Email == enrollCourse.StudentEmail).FirstOrDefault();
            if (student == null)
            {
                _db.Students.Add(new Student()
                {
                    StudentName = enrollCourse.StudentEmail,
                    Email = enrollCourse.StudentEmail
                });
                 _db.SaveChangesAsync();
                Student newstudent =  _db.Students.Where(s => s.Email == enrollCourse.StudentEmail)
                    .FirstOrDefault();
                StudentCourse studentCourse = new StudentCourse()
                {
                    StudentCourseId = newstudent.StudentId,
                    CouserId = enrollCourse.CourseId
                };
                 _db.StudentCourses.AddAsync(studentCourse);
                 _db.SaveChangesAsync();
                return 200;

            }
            else
            {
                StudentCourse studentCourse = new StudentCourse()
                {
                    StudentId = student.StudentId,
                    CouserId = enrollCourse.CourseId
                };
                _db.StudentCourses.AddAsync(studentCourse);
                _db.SaveChangesAsync();
                return 200;

            }

        }

        public IEnumerable<Course> GetEnrolledCourse(string UserEmail)
        {
            throw new NotImplementedException();
        }

        public int UnEnrollCourse(EnrollCourse unenrollCourse)
        {
            throw new NotImplementedException();
        }
    }
}
