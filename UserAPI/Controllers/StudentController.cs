
using Microsoft.AspNetCore.Mvc;

using StudentAPI.Repository;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentController : Controller
    {
        IStudentRepo _studentRepo;
     
        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        [HttpGet("{studentEmail}")]
        
        public async Task< Student> GetProfile(string studentEmail)
        {
           
            return _studentRepo.GetProfile(studentEmail);
        }
        [HttpPost]
       
        public async Task<IActionResult> EditProfile ([FromBody] Student student)
        {
            if (student== null)
            {
                return StatusCode(StatusCodes.Status204NoContent, new 
                {
                    Status = "Error",
                    Message = "No Student Found With Similar Data"
                });
            }
            bool response=  _studentRepo.EditProfile(student);
            if (response)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, new
                {
                    Status = "Error",
                    Message = "No Student Found With Similar Data"
                });
            }
        }
    }
}
