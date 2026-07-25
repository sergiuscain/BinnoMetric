using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase, ICanAdd<EmployeeDTO>, ICanGet<EmployeeDTO>, ICanUpdate<EmployeeDTO>, ICanDelete<int>
    {
        private readonly EmployeesService _employeesService;
        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpPost("AddEmployee")]
        public async Task<EmployeeDTO> AddAsync(EmployeeDTO employee)
        {
            throw new NotImplementedException();
            //return await _employeesService.AddEmployee(employee);
        }

        [HttpPost("AddEmployees")]
        public Task<ICollection<EmployeeDTO>> AddRangeAsync(ICollection<EmployeeDTO> values)
        {
            throw new NotImplementedException();
        }
        [HttpPut("DeleteEmployee")]
        public Task<bool> DeleteAsync(int employeeId)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetEmployees")]
        public Task<ICollection<EmployeeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetEmployee")]
        public Task<EmployeeDTO> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateEmployee")]
        public Task<EmployeeDTO> UpdateAsync(EmployeeDTO value)
        {
            throw new NotImplementedException();
        }
    }
}
