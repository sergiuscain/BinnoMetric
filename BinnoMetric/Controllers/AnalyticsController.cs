using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly AnalyticsService _analyticsService;
    public AnalyticsController(AnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }
    /// <summary>
    /// Рассчитывает топ сотрудников по производительности за смену на конкретном продукте
    /// </summary>
    /// <param name="productId">Id продукта</param>
    /// <param name="minRecord">Минимальное количество записей для учёта в статистике. 
    /// Если у сотрудника записей меньше, чем minRecord, в топе он не отобразиться</param>
    /// <param name="startDate">В статистике будут учитываться только записи начиная с даты startDate (включая эту дату)</param>
    /// <param name="endDate">В статистике будут учитываться только записи заканчивающиеся не позже даты endDate (включая эту дату)</param>
    /// <returns>Возвращает модель данных, которая содержит наименование продукта, его Id
    /// и коллекцию записей статистики для каждого сотрудника, которые содержат Имя, количество смен, 
    /// сколько всего выпущено продукции этим сотрудником и среднее количество продукции за смену</returns>
    [HttpGet("GetTopEmployee")]
    public async Task<TopEmployeesForCurrentProductDTO> GetTopEmployees(
    int productId,
    int? minRecord = 0,
    string? startDate = null,
    string? endDate = null)
    {
        var ru = new CultureInfo("ru-RU");

        DateTime? start = string.IsNullOrWhiteSpace(startDate)
            ? null
            : DateTime.Parse(startDate, ru);

        DateTime? end = string.IsNullOrWhiteSpace(endDate)
            ? null
            : DateTime.Parse(endDate, ru).AddDays(1).AddTicks(-1);

        return await _analyticsService.GetTopEmployees(productId, minRecord, start, end);
    }
}
