namespace MiniHRIS4.Models
{
    public class Department
    {
        public Department() => new HashSet<Employee>();
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}