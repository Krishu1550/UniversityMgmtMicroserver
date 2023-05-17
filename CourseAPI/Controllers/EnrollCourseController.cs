using EnrollCoursesAPI.Repositiory;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CourseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollCourseController : Controller
    {
            IEnrollCourseRepo _enrollCourseRepo { get; set; }   
            public EnrollCourseController(IEnrollCourseRepo enrollCourseRepo) 
            { 
                    _enrollCourseRepo = enrollCourseRepo;   
            }

        [HttpGet("{userEmail}")]
        public IEnumerable<Course> GetEnrollCourse(string userEmail)
        {
            return _enrollCourseRepo.GetEnrolledCourse(userEmail);
        }
        
        
        [HttpPost]
        [Route("enrollCourse")]

        public IActionResult  EnrollCourse([FromBody]EnrollCourse course)
        {
            _enrollCourseRepo.EnrollCourse(course);
            return Ok();
        }

        [HttpPost]
        [Route("unenrollCourse")]
        public IActionResult UnEnrollCourse([FromBody] EnrollCourse course) 
        {
            _enrollCourseRepo.UnEnrollCourse(course);

            return Ok();        
        }

    }
}
