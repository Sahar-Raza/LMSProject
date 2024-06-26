using LMSProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSProject.Data
{
    public class LMSDbContext(DbContextOptions<LMSDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Course entity
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseID); // Primary key
            });

            // Configure other entities as needed

            // Configure relationships
            modelBuilder.Entity<UserCourse>(entity =>
            {
                entity.HasKey(uc => new { uc.UserID, uc.CourseID });

                entity.HasOne(uc => uc.User)
                      .WithMany(u => u.UserCourses)
                      .HasForeignKey(uc => uc.UserID);

                entity.HasOne(uc => uc.Course)
                      .WithMany(c => c.UserCourses)
                      .HasForeignKey(uc => uc.CourseID);
            });
        }
    }
}
