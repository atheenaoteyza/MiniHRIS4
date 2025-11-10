namespace MiniHRIS4.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}