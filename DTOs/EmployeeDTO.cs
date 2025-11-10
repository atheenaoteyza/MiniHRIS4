namespace MiniHRIS4.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime DateHired { get; set; } = DateTime.UtcNow;
        public int DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}