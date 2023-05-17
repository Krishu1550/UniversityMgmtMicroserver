


    public class TeacherRepo : ITeacherRepo
    {
        CourseDbContext _db;

        public TeacherRepo(CourseDbContext db) { 
              

            _db = db;
         }

        public  int CreateTeacher(Teacher teacher)
        {
           if(teacher == null)
            {
                return 204;
            }
            _db.Teachers.Add(teacher);
            return 200;
        }

        public int DeleteTeacherById(int id)
        {
            if (id == 0)
            {
                return 204;
            }
            Teacher teacher = _db.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null) { return 404; }
            _db.Teachers.Remove(teacher);
            return 200;
        }

        public IEnumerable<Teacher> GetAllTeacher()
        {
            return _db.Teachers.ToList();
        }

        public Teacher GetTeacherById(int id)
        {
          
            return _db.Teachers.FirstOrDefault(t => t.TeacherId == id);
        }

        public int UpdateTeacher(Teacher teacher)
        {
            Teacher oldteacher = _db.Teachers.FirstOrDefault(
                t => t.TeacherId == teacher.TeacherId);
            if (teacher == null) { return 404; }
            oldteacher.TeacherName=teacher.TeacherName;
            return 200;
        }
    }

