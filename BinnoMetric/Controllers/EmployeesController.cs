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
    /// <summary>
    /// Добавляет сотрудника
    /// </summary>
    /// <param name="employee">Модель сотрудника</param>
    /// <returns>Добавленная модель или null</returns>
    [HttpPost("Add")]
    public async Task<EmployeeDTO> AddAsync(EmployeeDTO employee)
    {
        return await _employeesService.AddAsync(employee);
    }
    /// <summary>
    /// Добавляет коллекцию сотрудников
    /// </summary>
    /// <param name="values">Коллекция сотрудников</param>
    /// <returns>Добавленная коллекция сотрудников или null</returns>
    [HttpPost("AddCollection")]
    public async Task<ICollection<EmployeeDTO>> AddRangeAsync(ICollection<EmployeeDTO> values)
    {
        return await _employeesService.AddRangeAsync(values);
    }
    /// <summary>
    /// Удаляет сотрудника по Id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <returns>True в случае успеха</returns>
    [HttpPut("Delete")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _employeesService.DeleteAsync(id);
    }
    /// <summary>
    /// Возвращает всех сотрудников
    /// </summary>
    /// <returns>Возвращает коллекцию сотрудников или null</returns>
    [HttpGet("GetAll")]
    public async Task<ICollection<EmployeeDTO>> GetAllAsync()
    {
        return await _employeesService.GetAllAsync();
    }
    /// <summary>
    /// Получает сотрудника по Id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <returns>Сотрудник или null</returns>
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
