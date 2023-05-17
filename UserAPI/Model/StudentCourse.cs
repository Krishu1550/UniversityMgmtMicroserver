using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentCourseId { get; set; }
       
       public string StudentEmail { get; set; }

        public int CouserId { get; set; }
     

    }

