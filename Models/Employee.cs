namespace MiniHRIS4.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime DateHired { get; set; } = DateTime.UtcNow;
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}