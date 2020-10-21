using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        

        private readonly ILogin _login;
        

        public LoginController(ILogin login)
        {
            _login = login;
        }
        
        
        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromBody] LoginDTO logindetails)
        {
            return Ok(await _login.Login(logindetails));
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] PostUserDTO logindetails)
        {
            return Ok(await _login.AddUser(logindetails));
        }

    }
}