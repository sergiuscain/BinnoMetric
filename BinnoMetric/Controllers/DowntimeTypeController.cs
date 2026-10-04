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
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("UpdateDowntimeType")]
    public async Task<DowntimeTypeDTO> UpdateAsync(DowntimeTypeDTO value)
    {
        return await _downtimeTypeService.UpdateAsync(value);
    }
    /// <summary>
    /// Добавляет тип простоя
    /// </summary>
    /// <param name="value">Модель содержащая тип простоя (механическая поломка, генеральная уборка, ежедневная уборка и прочие ТИПЫ простоев)</param>
    /// <returns></returns>
    [HttpPost("AddDowntimeType")]
    public async Task<DowntimeTypeDTO> AddAsync(DowntimeTypeDTO value)
    {
        return await _downtimeTypeService.AddAsync(value);
    }
    /// <summary>
    /// Добавляет коллекцию типов простоев
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    [HttpPost("AddDowntimeTypes")]
    public async Task<ICollection<DowntimeTypeDTO>> AddRangeAsync(ICollection<DowntimeTypeDTO> values)
    {
        return await _downtimeTypeService.AddRangeAsync(values);
    }
    /// <summary>
    /// Получает тип простоя по его Id
    /// </summary>
    /// <param name="id">Id простоя, целочисленное значение</param>
    /// <returns></returns>
    [HttpGet("GetDowntimeType")]
    public async Task<DowntimeTypeDTO> GetAsync(int id)
    {
        return await _downtimeTypeService.GetAsync(id);
    }
    /// <summary>
    /// Получает все типы простоев
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetDowntimeTypes")]
    public async Task<ICollection<DowntimeTypeDTO>> GetAllAsync()
    {
        return await _downtimeTypeService.GetAllAsync();
    }
}
