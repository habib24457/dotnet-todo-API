using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace LoginController.Controllers
{
    [Route("api/signin")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly LoginContext _context;

        public LoginController(LoginContext loginContext)
        {
            _context = loginContext;
        }


    }
}