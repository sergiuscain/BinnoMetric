using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DowntimeRecordController : ControllerBase

{
    private readonly DowntimeRecordService _downtimeRecordService;
    public DowntimeRecordController(DowntimeRecordService downtimeRecordService)
    {
        _downtimeRecordService = downtimeRecordService;
    }
    /// <summary>
    /// Создает запись простоя линии
    /// </summary>
    /// <param name="value">Модель данных простоя</param>
    /// <returns>Возвращает добавленную запись</returns>
    [HttpPost("Add")]
    public async Task<DowntimeRecordDTO> AddAsync(DowntimeRecordDTO value)
    {
        return await _downtimeRecordService.AddAsync(value);
    }
    /// <summary>
    /// Создает список записей простоя
    /// </summary>
    /// <param name="values">Коллекция записей простоя</param>
    /// <returns>Возвращает добавленную коллекцию записей</returns>
    [HttpPost("AddCollection")]
    public async Task<ICollection<DowntimeRecordDTO>> AddRangeAsync(ICollection<DowntimeRecordDTO> values)
    {
        return await _downtimeRecordService.AddRangeAsync(values);
    }
    /// <summary>
    /// Получает запись простоя по его Id
    /// </summary>
    /// <param name="id">Id записи простоя, целочисленное значение</param>
    /// <returns>Возвращает запись простоя</returns>
    [HttpGet("Get")]
    public async Task<DowntimeRecordDTO> GetAsync(int id)
    {
        return await _downtimeRecordService.GetAsync(id);
    }
    /// <summary>
    /// Получает все записи простоя
    /// </summary>
    /// <returns>Возвращает коллекцию записей простоя</returns>
    [HttpGet("GetAll")]
    public async Task<ICollection<DowntimeRecordDTO>> GetAllAsync()
    {
        return await _downtimeRecordService.GetAllAsync();
    }
    /// <summary>
    /// Обновляет запись простоя
    /// </summary>
    /// <param name="value">Модель записи простоя с новыми данными, но тем же Id, что был раньше</param>
    /// <returns>Возвращает обновленную запись</returns>
    [HttpPut("Update")]
    public async Task<DowntimeRecordDTO> UpdateAsync(DowntimeRecordDTO value)
    {
        return await _downtimeRecordService.UpdateAsync(value);
    }
    /// <summary>
    /// Удаляет запись простоя
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает True в случае успеха</returns>
    [HttpDelete("Delete")]
    public async Task<bool> DeleteAsync(DowntimeRecordDTO value)
    {
        return await _downtimeRecordService.DeleteAsync(value);
    }
}
