using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace SignUpController.Controllers
{
    [Route("api/signup")]
    [ApiController]

    public class SignUpController : ControllerBase
    {
        private readonly MyDbContext _signupContext;

        public SignUpController(MyDbContext signUpContext)
        {
            _signupContext = signUpContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _signupContext.SignUps.ToListAsync();
            return Ok(users);

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] SignUp signUp)
        {
            var addUser = new SignUp
            {
                Id = signUp.Id,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                Password = signUp.Password,
                Reason = signUp.Reason
            };
            _signupContext.SignUps.Add(addUser);
            await _signupContext.SaveChangesAsync();

            return CreatedAtAction("CreateUser", new { id = signUp.Id }, signUp);
        }

    }
}