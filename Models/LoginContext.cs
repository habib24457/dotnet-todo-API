using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<Login> LoginTable { get; set; } = null;
    }
}