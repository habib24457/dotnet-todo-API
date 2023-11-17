using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
    {

    }

    public DbSet<TodoItem> TodoItems { get; set; } = null;
    public DbSet<SignUp> SignUps { get; set; } = null;
}