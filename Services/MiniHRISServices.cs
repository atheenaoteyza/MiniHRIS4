using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniHRIS4.DTOs;
using MiniHRIS4.Models;

namespace MiniHRIS4.Services
{
    public class MiniHRISServices
    {
        private readonly MiniHRIS4Context _context;
        public MiniHRISServices(MiniHRIS4Context context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDTO>> GetEmployeeDTOsAsync()
        {
            return await _context.Employees.Include(a => a.Department).Select(a => new EmployeeDTO
            {
                EmployeeId = a.EmployeeId,
                FirstName = a.FirstName,
                Lastname = a.Lastname,
                DateHired = a.DateHired,
                DepartmentId = a.DepartmentId,
                Department = new DepartmentDTO
                {
                    DepartmentId = a.DepartmentId,
                    Name = a.Department.Name
                }
            }
            ).ToListAsync();
        }
    }
}