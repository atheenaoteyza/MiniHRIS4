using Microsoft.AspNetCore.Mvc;
using MiniHRIS4.Services;

namespace MiniHRIS4.Controller
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
    }
}