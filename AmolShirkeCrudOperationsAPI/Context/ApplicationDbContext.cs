using AmolShirkeCrudOperationsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AmolShirkeCrudOperationsAPI.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            // Similarly for other relationships:
            modelBuilder.Entity<Student>()
                        .HasOne(s => s.State)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
                        .HasOne(s => s.City)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
