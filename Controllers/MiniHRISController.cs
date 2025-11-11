using Microsoft.AspNetCore.Mvc;
using MiniHRIS4.Services;

namespace MiniHRIS4.Controllers
{
    [Route("employees")]
    public class MiniHRISController : ControllerBase
    {
        private readonly MiniHRISServices _hrisService;

        public MiniHRISController(MiniHRISServices hrisService)
        {
            _hrisService = hrisService;
        }

        [HttpGet("test-employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _hrisService.GetEmployeeDTOsAsync();
            return Ok(employees);
        }
        [HttpGet("db-error-test")]
        public async Task<IActionResult> DbErrorTest()
        {
            // deliberately use wrong query to trigger an exception
            var list = await _hrisService.DbErrorTest();
            if (list is null)
            {
                throw new Exception("Db not found");
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var emp = await _hrisService.GetEmployeeByIdOrThrowAsync(id);
            return Ok(emp);
        }

    }
}