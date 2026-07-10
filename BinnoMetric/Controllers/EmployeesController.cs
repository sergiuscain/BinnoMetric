using BinnoMetric.Models;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesService _employeesService;
        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _employeesService.AddEmployee(employee);
            return Ok(employee);
        }
    }
}
