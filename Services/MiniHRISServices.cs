using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniHRIS4.DTOs;
using MiniHRIS4.Models;
using MiniHRIS4.Exceptions;
using Serilog;

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
            Log.Information("Fetching employees...");
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


        public async Task<List<Employee>> DbErrorTest()
        {
            // deliberately use wrong query to trigger an exception
            try
            {
                Log.Information("Testing Db...");

                return await _context.Employees
                 .FromSqlRaw("SELECT * FROM NonExistentTable")
                 .ToListAsync();

            }
            catch (Exception ex)
            {
                Log.Error(ex, "this is a database error");
                throw;
            }


        }

        public async Task<EmployeeDTO> GetEmployeeByIdOrThrowAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                Log.Warning("Employee {EmployeeId} not found", id);
                throw new NotFoundException("No employee found");

            }
            Log.Information("Successfully retrieved employee {EmployeeId}", id);

            // Map to DTO
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                Lastname = employee.Lastname,
                DateHired = employee.DateHired,
                DepartmentId = employee.DepartmentId,
                Department = employee.Department == null ? null : new DepartmentDTO
                {
                    DepartmentId = employee.Department.DepartmentId,
                    Name = employee.Department.Name
                }
            };
        }



    }
}