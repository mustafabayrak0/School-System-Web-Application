using Microsoft.EntityFrameworkCore;
using SchoolLoginSystem.Models;
using System.Collections.Generic;
using System;

namespace SchoolLoginSystem.Models
{
    public class ContextForStudent : DbContext
    {
        public ContextForStudent() { }
        public ContextForStudent(DbContextOptions<ContextForStudent> options) : base(options) { }

        public DbSet<ModelForStudent> studentModels { get; set; }
        public DbSet<ModelForTeacher> teacherModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost; Port=5432; User Id=postgres;Password=123456;Database=SystemLogin;"
 );
    }
}

