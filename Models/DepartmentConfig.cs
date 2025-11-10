using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiniHRIS4.Models
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.HasKey(a => a.DepartmentId);
            entity.Property(a => a.Name).IsRequired().HasMaxLength(200);

            entity.HasData(
                new Department { DepartmentId = 1, Name = "IT Department" },
                new Department { DepartmentId = 2, Name = "Human Resource" },
                new Department { DepartmentId = 3, Name = "Finance Department" }
            );

        }
    }
}