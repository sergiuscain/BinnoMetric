using BinnoMetric.Abstractions;
using BinnoMetric.Models;
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
        [HttpPost("Add")]
        public async Task<Employee> AddAsync(Employee employee)
        {
            return await _employeesService.AddEmployee(employee);
        }


        public Task<ICollection<Employee>> AddRangeAsync(ICollection<Employee> values)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CanDeleteAsync(Employee value)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee value)
        {
            throw new NotImplementedException();
        }
    }
}
