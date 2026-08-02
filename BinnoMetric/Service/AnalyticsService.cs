using BinnoMetric.DataBase;
using BinnoMetric.DTO;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;

public class AnalyticsService
{
    private readonly BinnoDBContext _dBContext;
    public AnalyticsService(BinnoDBContext dbContext)
    {
        _dBContext = dbContext;
    }

    internal async Task<TopEmployeesForCurrentProductDTO> GetTopEmployees(
        int productId,
        int? minRecord,
        DateTime? startDate = null,
        DateTime? endDate = null)
    {
        var currentProductRecord = _dBContext.ProductionRecords
            .Where(x => x.ProductId == productId);

        // Фильтрация по дате (если указана)
        if (startDate.HasValue)
            currentProductRecord = currentProductRecord.Where(x => x.StartTime >= startDate.Value);

        if (endDate.HasValue)
            currentProductRecord = currentProductRecord.Where(x => x.StartTime <= endDate.Value);

        var currentProductRecordForPeriod = await currentProductRecord.ToListAsync();

        var product = await _dBContext.Products
            .FirstOrDefaultAsync(x => x.Id == productId);

        TopEmployeesForCurrentProductDTO stat = new TopEmployeesForCurrentProductDTO();
        stat.ProductId = productId;
        stat.ProductName = product?.Name ?? "Неизвестный продукт";
        stat.EmployeesStat = new List<EmployeeStatDTO>();

        var allOperatorIds = currentProductRecordForPeriod
            .SelectMany(r => new[] { r.OperatorDId, r.OperatorNKLId })
            .Distinct()
            .ToList();

        var employees = await _dBContext.Employees
            .Where(x => allOperatorIds.Contains(x.Id))
            .ToListAsync();

        var employeesStat = employees
            .Select(employee => new EmployeeStatDTO
            {
                FullName = employee.FullName,
                TotalProductsCount = currentProductRecordForPeriod
                    .Where(x => x.OperatorDId == employee.Id || x.OperatorNKLId == employee.Id)
                    .Sum(x => x.ActualQuantity),
                ShiftsCount = currentProductRecordForPeriod
                    .Where(x => x.OperatorDId == employee.Id || x.OperatorNKLId == employee.Id)
                    .DistinctBy(x => x.StartTime).Count()
            })
            .Select(stat =>
            {
                stat.AverageProductsCount = stat.ShiftsCount > 0
                    ? stat.TotalProductsCount / stat.ShiftsCount
                    : 0;
                return stat;
            })
            .ToList();
        if(minRecord > 0)
        {
            stat.EmployeesStat = employeesStat
                .Where(x => x.ShiftsCount >= minRecord)
                .OrderByDescending(x => x.AverageProductsCount)
                .ToList();
        }
        else
        {
            stat.EmployeesStat = employeesStat
                .OrderByDescending(x => x.AverageProductsCount)
                .ToList();
        }

        return stat;
    }
}