using Microsoft.EntityFrameworkCore;
using StudentTransferManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data
{
    public class ManagementSystemContext : DbContext
    {

        public ManagementSystemContext(DbContextOptions<ManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CustomFile> CustomFiles { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
