using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase, ICanAdd<Employee>, ICanGet<Employee>, ICanUpdate<Employee>, ICanDelete<Employee>
    {
        private readonly EmployeesService _employeesService;
        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpPost("AddEmployee")]
        public async Task<Employee> AddAsync(Employee employee)
        {
            return await _employeesService.AddEmployee(employee);
        }

        [HttpPost("AddEmployees")]
        public Task<ICollection<Employee>> AddRangeAsync(ICollection<Employee> values)
        {
            throw new NotImplementedException();
        }
        [HttpPut("DeleteEmployee")]
        public Task<bool> CanDeleteAsync(Employee value)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetEmployees")]
        public Task<ICollection<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetEmployee")]
        public Task<Employee> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateEmployee")]
        public Task<Employee> UpdateAsync(Employee value)
        {
            throw new NotImplementedException();
        }
    }
}
