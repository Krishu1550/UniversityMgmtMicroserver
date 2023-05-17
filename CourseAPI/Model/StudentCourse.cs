using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


    public class StudentCourse
    {

        [Key]
        public int StudentCourseId { get; set; }

        
        public string StudentEmail { get; set; }


        [ForeignKey("Course")]
        public int CouserId { get; set; }
        public Course Course { get; set; }

    }

