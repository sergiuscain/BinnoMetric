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
