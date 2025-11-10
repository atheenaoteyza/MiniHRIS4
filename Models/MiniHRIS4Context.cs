using Microsoft.EntityFrameworkCore;

namespace MiniHRIS4.Models
{
    public class MiniHRIS4Context : DbContext
    {
        public MiniHRIS4Context(DbContextOptions<MiniHRIS4Context> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());

            modelBuilder.Entity<Employee>().HasOne(a => a.Department).WithMany(a => a.Employees).HasForeignKey(a => a.DepartmentId);
        }
    }
}