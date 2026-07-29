using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
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
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            return await _analyticsService.GetTopEmployees(productId, minRecord, startDate, endDate);
        }
    }
}
