using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductionRecordsController : ControllerBase
{
    private readonly ProductionRecordsService _productionRecordsService;
    public ProductionRecordsController(ProductionRecordsService productionRecordsService)
    {
        _productionRecordsService = productionRecordsService;
    }
    /// <summary>
    /// Добавление производственной записи
    /// </summary>
    /// <param name="value">Производственная запись</param>
    /// <returns>Возвращает добавленную запись или null</returns>
    [HttpPost("AddProductionRecord")]
    public async Task<ProductionRecordDTO> AddAsync(ProductionRecordDTO value)
    {
        return await _productionRecordsService.AddAsync(value);
    }
    /// <summary>
    /// Добавляет коллекцию производственных записей
    /// </summary>
    /// <param name="values">Коллекция записей</param>
    /// <returns>Возвращает добавленную коллекцию или null</returns>
    [HttpPost("AddProductionRecords")]
    public async Task<ICollection<ProductionRecordDTO>> AddRangeAsync(ICollection<ProductionRecordDTO> values)
    {
        return await _productionRecordsService.AddRangeAsync(values);
    }
    /// <summary>
    /// Удаляет производственную запись по её ID
    /// </summary>
    /// <param name="id">ID производственной записи</param>
    /// <returns>true в случае успеха, иначе false</returns>
    [HttpDelete("DeleteProductionRecord")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _productionRecordsService.DeleteAsync(id);
    }
    /// <summary>
    /// Получает все производственные записи с учётом фильтров
    /// </summary>
    /// <param name="filter">Модель данных, включающая разные параметры фильтрации</param>
    /// <returns>Возвращает записи удовлетворяющие фильтры или пустую коллекцию</returns>
    [HttpPost("GetProductionRecords")]
    public async Task<ICollection<ProductionRecordDTO>> GetAllAsync([FromBody] ProductionRecordFilter filter)
    {
        return await _productionRecordsService.GetAllAsync(filter);
    }
    /// <summary>
    /// Получение производственной записи по ID
    /// </summary>
    /// <param name="id">ID производственной записи</param>
    /// <returns>Производственная запись</returns>
    [HttpGet("GetProductionRecord")]
    public async Task<ProductionRecordDTO> GetAsync(int id)
    {
        return await _productionRecordsService.GetAsync(id);
    }
    /// <summary>
    /// Получение количества страниц с учётом пагинации и фильтров
    /// </summary>
    /// <param name="filter">Фильтр, включающий в себя параметры фильтрации и пагинации</param>
    /// <returns>Число страниц, доступных при текущих фильтрах и количеством записей на одной странице</returns>
    [HttpPost("GetPageCount")]
    public async Task<int> GetPageCount([FromBody] ProductionRecordFilter filter)
    {
        filter.isPaginate = false;
        return await _productionRecordsService.GetPageCount(filter);
    }
    /// <summary>
    /// Обновляет производственную запись
    /// </summary>
    /// <param name="value">Произволдственная запись с новыми данными, но прежним ID</param>
    /// <returns>Новая запись или null</returns>
    [HttpPut("UpdateProductionRecord")]
    public async Task<ProductionRecordDTO> UpdateAsync(ProductionRecordDTO value)
    {
        return await _productionRecordsService.UpdateAsync(value);
    }
}
