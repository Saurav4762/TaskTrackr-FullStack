using Microsoft.EntityFrameworkCore;
using TaskTrackr.Entities;

namespace TaskTrackr.Data
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
        {
        }
        
        public DbSet<Assignment> Assignments { get; set; }
        
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Assignment>().ToTable("Assignments");
        }

    }
}