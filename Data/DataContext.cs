using Microsoft.EntityFrameworkCore;
using Uranus.Models;

namespace Uranus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

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
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Lesson>()
                .HasOne(c => c.Course)
                .WithMany(l => l.Lessons)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Test>()
                .HasOne(c => c.Course)
                .WithMany(t => t.Tests)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doc>()
                .HasOne(l => l.Lesson)
                .WithMany(d => d.Docs)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Video>()
                .HasOne(l => l.Lesson)
                .WithMany(v => v.Videos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Homework>()
                .HasOne(l => l.Lesson)
                .WithMany(h => h.Homeworks)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Material>()
                .HasOne(h => h.Homework)
                .WithMany(m => m.Materials) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
