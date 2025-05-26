using Microsoft.EntityFrameworkCore;
using SmartTasker.Models;

namespace SmartTasker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
