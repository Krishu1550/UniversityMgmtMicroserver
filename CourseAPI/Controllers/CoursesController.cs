

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace CourseAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CoursesController : ControllerBase
    {
        public ICourseRepo _courseRepo { get; set; }
        public CoursesController(ICourseRepo courseRepo)

        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
       
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseRepo.GetAllCourses();
        }
        [HttpGet("{id}")]
       
        public async Task<Course> GetCourseById ( int id)

        {
            return await _courseRepo.GetCourseById(id);
        }

        [HttpPost]

        public async Task<IActionResult>  CreateCourse([FromBody] Course course)
        {
            int  response =await _courseRepo.CreateCourse(course);
            if (response == 0)
            {
                Ok();

            }
            else if (response == 1) 
            {

                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable, new
                {
                    Status = "Error",
                    Message = "Num of classes and slot can more than 3 "
                });

            }
            else if (response == 2)
            {
                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable,
                       new
                       {
                           Status = "Error",
                           Message = "Create more ClassRooms"
                       });
            }
         
                return BadRequest();
            

        }
        [HttpPut]
     
        public async Task <IActionResult> UpdateCourse([FromBody] Course course)
        {
            int response= await _courseRepo.UpdateCourse(course);
            if( response==0)
            {
                return Ok();
            }
            else if (response==1)
            {
                return NoContent();
            }
            else if (response==2)
            {
                return NotFound();
            }
            else if (response==3 )
            {
                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable,
                          new 
                          {
                              Status = "Error",
                              Message = "Create more ClassRooms"
                          });
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
    
        public async Task<IActionResult> DeleteCourse( int id)
        {
           int  response= await _courseRepo.DeleteCourse(id);
            if(response==0)
            {
                return Ok();
            }
            if (response==1)
            {
                return NotFound() ;
            }
            if(response==2)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                   new 
                   {
                       Status = "Error",
                       Message = "No Course fount at id: " + id

                   });

            }
            return BadRequest();
        }
  

    }
}
