using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class SignUp
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reason { get; set; }
    }
}