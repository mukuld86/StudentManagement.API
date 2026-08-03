using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Models;

namespace StudentManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
