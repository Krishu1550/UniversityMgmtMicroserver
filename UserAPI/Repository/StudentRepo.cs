using Azure;
using Microsoft.EntityFrameworkCore;
using StudentAPI.DataBase;


namespace StudentAPI.Repository
{
    public class StudentRepo : IStudentRepo
    {
        StudentDBContext _db;
        public StudentRepo(StudentDBContext studentDBContext) {
            _db = studentDBContext;
        }
        public bool EditProfile(Student student)
        {
            var editStudent = _db.Students.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
       
            if (editStudent == null)
            {
                return false;

            }
            editStudent.StudentName = student.StudentName;
            editStudent.DateOfBirth = student.DateOfBirth;
             _db.SaveChangesAsync();

           return true;
        }

        public Student GetProfile(string StudentEmail)
        {
            Student student =  _db.Students.Where(s => s.Email == StudentEmail).FirstOrDefault();

            if (student == null)
            {
                _db.Students.Add(new Student()
                {
                    StudentName = StudentEmail,
                    Email = StudentEmail
                });
                 _db.SaveChangesAsync();
                Student newstudent = _db.Students.Where(s => s.Email == StudentEmail).FirstOrDefault();
                return newstudent;
            }
            return student;
        }

       
    }
}
