using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Student.Domain;

namespace Student.Data
{
   public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>option)
            : base(option)
        { }

        public DbSet<StudentInfo> studentInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
