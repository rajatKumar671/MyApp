using Microsoft.EntityFrameworkCore;
using Student.Domain;

namespace Student.Data
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> option)
            : base(option)
        { }

        public DbSet<Students> students { get; set; }
        public DbSet<Standard> standards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().HasOne(p => p.Standard).WithMany(b => b.students);
        }

    }
}
