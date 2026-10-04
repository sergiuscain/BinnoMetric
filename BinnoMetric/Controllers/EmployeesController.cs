using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

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
    public async Task<EmployeeDTO> AddAsync(EmployeeDTO employee)
    {
        return await _employeesService.AddAsync(employee);
    }

    [HttpPost("AddCollection")]
    public async Task<ICollection<EmployeeDTO>> AddRangeAsync(ICollection<EmployeeDTO> values)
    {
        return await _employeesService.AddRangeAsync(values);
    }
    [HttpPut("Delete")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _employeesService.DeleteAsync(id);
    }
    [HttpGet("GetAll")]
    public async Task<ICollection<EmployeeDTO>> GetAllAsync()
    {
        return await _employeesService.GetAllAsync();
    }
    [HttpGet("Get")]
    public async Task<EmployeeDTO> GetAsync(int id)
    {
        return await _employeesService.GetAsync(id);
    }
    // Потом разберусь, как правильно обновлять сотрудника. Там надо с парсингом в DTO и обратно разобраться.
    ////internal async Task<EmployeeDTO> UpdateAsync(EmployeeDTO value)
    ////[HttpPut("UpdateEmployee")]
    ////public async Task<EmployeeDTO> UpdateAsync(EmployeeDTO value)
    ////{
    ////    return await _employeesService.UpdateAsync(value);
    ////}
}
