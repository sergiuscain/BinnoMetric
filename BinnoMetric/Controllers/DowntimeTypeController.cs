using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DowntimeTypeController : ControllerBase
{
    private readonly DowntimeTypeService _downtimeTypeService;
    public DowntimeTypeController(DowntimeTypeService downtimeTypeService)
    {
        _downtimeTypeService = downtimeTypeService;
    }
    /// <summary>
    /// Удаляет запись "тип простоя" по Id
    /// </summary>
    /// <param name="id">Id типа простоя</param>
    /// <returns>В случае успеха, возвращает true</returns>
    [HttpDelete("Delete")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _downtimeTypeService.DeleteAsync(id);
    }
    /// <summary>
    /// Обновляет тип простоя
    /// </summary>
    /// <param name="value">Тип простоя с измененными данными. Id должен соответствовать тому типу простоя, который требуется обновить</param>
    /// <returns>Обновленный тип простоя или null</returns>
    [HttpPut("Update")]
    public async Task<DowntimeTypeDTO> UpdateAsync(DowntimeTypeDTO value)
    {
        return await _downtimeTypeService.UpdateAsync(value);
    }
    /// <summary>
    /// Добавляет тип простоя
    /// </summary>
    /// <param name="value">Модель содержащая тип простоя (механическая поломка, генеральная уборка, ежедневная уборка и прочие ТИПЫ простоев)</param>
    /// <returns>Возвращает добавленную модель или null</returns>
    [HttpPost("Add")]
    public async Task<DowntimeTypeDTO> AddAsync(DowntimeTypeDTO value)
    {
        return await _downtimeTypeService.AddAsync(value);
    }
    /// <summary>
    /// Добавляет коллекцию типов простоев
    /// </summary>
    /// <param name="values">Коллекция типов простоя</param>
    /// <returns>Возвращает добавленную коллекцию или null</returns>
    [HttpPost("AddCollection")]
    public async Task<ICollection<DowntimeTypeDTO>> AddRangeAsync(ICollection<DowntimeTypeDTO> values)
    {
        return await _downtimeTypeService.AddRangeAsync(values);
    }
    /// <summary>
    /// Получает тип простоя по его Id
    /// </summary>
    /// <param name="id">Id простоя, целочисленное значение</param>
    /// <returns>Тип простоя или null</returns>
    [HttpGet("Get")]
    public async Task<DowntimeTypeDTO> GetAsync(int id)
    {
        return await _downtimeTypeService.GetAsync(id);
    }
    /// <summary>
    /// Получает все типы простоев
    /// </summary>
    /// <returns>Коллекция типов простоя</returns>
    [HttpGet("GetAll")]
    public async Task<ICollection<DowntimeTypeDTO>> GetAllAsync()
    {
        return await _downtimeTypeService.GetAllAsync();
    }
}
