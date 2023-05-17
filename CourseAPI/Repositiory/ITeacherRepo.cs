using Microsoft.EntityFrameworkCore.Storage;



    public interface ITeacherRepo
    {


        IEnumerable<Teacher> GetAllTeacher();
        Teacher GetTeacherById(int id);
        int UpdateTeacher (Teacher teacher);
        int DeleteTeacherById(int id);  
        int CreateTeacher (Teacher teacher);    

    }

