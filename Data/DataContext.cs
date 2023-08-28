using Uranus.Models;
using Microsoft.EntityFrameworkCore;

namespace Uranus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<UserCourse> UserCourses { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>()
                .HasKey(pc => new { pc.UserId, pc.CourseId });
            modelBuilder.Entity<UserCourse>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.UserCourses)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserCourse>()
                .HasOne(p => p.Course)
                .WithMany(pc => pc.UserCourses)
                .HasForeignKey(c =>c.CourseId);
        }
    }
}
