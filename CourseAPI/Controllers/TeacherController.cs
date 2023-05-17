using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




	[Route("api/[controller]")]
	public class TeacherController : Controller
	{

		CourseDbContext _db;
	    ITeacherRepo _teacherRepo;

        public TeacherController(ITeacherRepo teacherRepo)
		{
            _teacherRepo = teacherRepo;
		}


		
		[HttpGet]
	
		public async Task<List<Teacher>> GetTeachers()
		{
		    return (List<Teacher>)_teacherRepo.GetAllTeacher();
		}

		[HttpPost]
		
		public async Task<IActionResult> CreateTeacher([FromBody] Teacher teacher)
		{
		   var response= _teacherRepo.CreateTeacher(teacher);

			if(teacher == null || response== 204)
			{
				return StatusCode( StatusCodes.Status404NotFound,
					new 
					{
						Status="Error",
						Message="Teacher is null"
					}
					);

			}
		
			
			return StatusCode(StatusCodes.Status200OK);
		}
		[HttpPut]

	
		public async Task<IActionResult> UpdateTeacher([FromBody] Teacher teacher)
		{
		 var response= _teacherRepo.UpdateTeacher(teacher);
			
			if(response == 404)
			{
				return StatusCode(StatusCodes.Status404NotFound,
					new 
					{
						Status="Error",
						Message="No Teacher found similiar"
					});
			}

			

			return StatusCode(StatusCodes.Status200OK);
		

		}
		[HttpGet("{id}")]
	
		public async Task<Teacher> GetTeacherById(int id)
		{
			


			return _teacherRepo.GetTeacherById(id);

		}


		[HttpDelete]
	
		public async Task<IActionResult> DeleteTeacher(int id)
		{
			var deleteTeacher = await _db.Teachers.Where(c => c.TeacherId == id).FirstOrDefaultAsync();
		    var response = _teacherRepo.DeleteTeacherById(id);
			if (response == 204)
			{

				return StatusCode(StatusCodes.Status404NotFound,
					new 
					{
						Status = "Error",
						Message = "No Teacher fount at id: " + id

					});


			}
		



			return StatusCode(StatusCodes.Status200OK);
		}


	}

