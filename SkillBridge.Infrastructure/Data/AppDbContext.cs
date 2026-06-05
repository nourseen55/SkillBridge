
using Microsoft.EntityFrameworkCore;
using SkillBridge.Domain.Entities;

namespace SkillBridge.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Progress> Progresses { get; set; }
       


    }
}
