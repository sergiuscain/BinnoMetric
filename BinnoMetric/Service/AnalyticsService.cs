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
    internal async Task<TopEmployeesForCurrentProductDTO> GetTopEmployees(int productId)
    {
        var productionRecordForCurrentProduct = await _dBContext.ProductionRecords
            .Where(x => x.ProductId == productId)
            .ToListAsync();
        var product = await _dBContext.Products
            .FirstOrDefaultAsync(x => x.Id == productId);

        TopEmployeesForCurrentProductDTO stat = new TopEmployeesForCurrentProductDTO();
        stat.ProductId = productId;
        stat.ProductName = product.Name;
        stat.EmployeesStat = new List<EmployeeStatDTO>();

        var allOperatorIds = productionRecordForCurrentProduct
            .SelectMany(r => new[] { r.OperatorDId, r.OperatorNKLId })
            .Distinct()
            .ToList();

        var employees = await _dBContext.Employees.Where(x => allOperatorIds.Contains(x.Id)).ToListAsync();
        foreach (var employee in employees)
        {
            EmployeeStatDTO employeeStat = new EmployeeStatDTO();
            employeeStat.ShortName = employee.ShortName;
            employeeStat.TotalProductsCount = productionRecordForCurrentProduct
                .Where(x => x.OperatorDId == employee.Id || x.OperatorNKLId == employee.Id)
                .Sum(x => x.ActualQuantity);
            employeeStat.ShiftsCount = productionRecordForCurrentProduct
                .Where(x => x.OperatorDId == employee.Id || x.OperatorNKLId == employee.Id)
                .DistinctBy(x => x.StartTime).Count();
            employeeStat.AverageProductsCount = employeeStat.TotalProductsCount / employeeStat.ShiftsCount;
            stat.EmployeesStat.Add(employeeStat);
        }
        return stat;
    }
}