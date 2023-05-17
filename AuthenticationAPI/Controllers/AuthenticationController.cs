using AuthenticationManager.Controller;
using AuthenticationManager.DataBase;
using AuthenticationManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthenticationController : Controller
    {
        private AuthDBContext _authDB;
        private JwtTokenHandler _jwtTokenHandler;
        public AuthenticationController(AuthDBContext authDB)
        {
            _authDB = authDB;
            _jwtTokenHandler = new JwtTokenHandler(_authDB);
        }
        [HttpPost]
        [Route("login")]
        public async Task<AuthenticationResponse?> Login([FromBody] AuthenticationRequest authentication)
        {
            if(authentication == null) {
                return null;
            }
          return await _jwtTokenHandler.GenerateJwtToken(authentication);
          

            
        }
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration([FromBody] UserAccount userAccount)
        {
            if(userAccount == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            bool respone = await _jwtTokenHandler.Registeration(userAccount);
            if (!respone)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return Ok();
        }
    }
}
