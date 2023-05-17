using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<StudentCourse>? studentCourses = new List<StudentCourse>();
    }

