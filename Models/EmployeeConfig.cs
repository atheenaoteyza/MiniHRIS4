using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiniHRIS4.Models
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(a => a.EmployeeId);
            entity.Property(a => a.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(a => a.Lastname).IsRequired().HasMaxLength(200);

            entity.HasData(
                new Employee { EmployeeId = 1, FirstName = "Christian", Lastname = "Vinas", DepartmentId = 1 },

                new Employee { EmployeeId = 2, FirstName = "Jon", Lastname = "Santos", DepartmentId = 2 }
            );
        }
    }
}