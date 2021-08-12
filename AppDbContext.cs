using Microsoft.EntityFrameworkCore;
using cv8_mvc.Models;
using System;
using System.IO;

namespace cv8_mvc
{
    public class AppDbContext : DbContext
    {
        private const string _sqliteFileName = "zp4cs_cv8.db";
        // connstr by asi spravneji mel byt v appsetting.json,
        // ale vzhledem k localhost platformam to radsi necham tak
        private string _connectionString
        {
            get
            {
                try
                {
                    if (Environment.OSVersion.Platform == PlatformID.Unix)
                    {
                        return Path.Combine("/tmp/", _sqliteFileName);
                    }
                    else if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        return Path.Combine(AppContext.BaseDirectory, _sqliteFileName);
                    }
                    else
                    {
                        throw new PlatformNotSupportedException($"Platform {Environment.OSVersion.Platform} is not supported.");
                    }
                }
                catch
                {
                    Utils.ConsoleWriteColoredLine("Error occurred while getting ConnectionString in AppDbContext class.", ConsoleColor.Red);
                    throw;
                }
            }
        }

        // Constructor needed for registration DbContext dependency as a Service in Startup.cs
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_connectionString}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // setting up 1:[M:N]:1 Student - StudentCourse - Course relation, composite PK
            modelBuilder.Entity<StudentCourse>()
                        .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                        .HasOne(sc => sc.Student)
                        .WithMany(s => s.StudentCourses)
                        .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                        .HasOne(sc => sc.Course)
                        .WithMany(c => c.StudentCourses)
                        .HasForeignKey(sc => sc.CourseId);

            // jak nastavit nejaky sloupec jako UNIQUE aniz by byl PKey nebo index? Student.OsCislo
            // modelBuilder.Entity<Student>().HasIndex(s => s.OsCislo).IsUnique();
            modelBuilder.Seed();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<CourseStatute> CourseStatutes { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}