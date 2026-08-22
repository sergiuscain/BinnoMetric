using BinnoMetric.DataBase;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;

public class ProductionRecordsService
{
    private readonly BinnoDBContext _dBContext;
    public ProductionRecordsService(BinnoDBContext dbContext)
    {
        _dBContext = dbContext;
    }
    internal async Task<ProductionRecordDTO> AddAsync(ProductionRecordDTO value)
    {
        try
        {
            await _dBContext.ProductionRecords.AddAsync(value.ToModel());
            await _dBContext.SaveChangesAsync();
            return value;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<ICollection<ProductionRecordDTO>> AddRangeAsync(ICollection<ProductionRecordDTO> values)
    {
        try
        {
            await _dBContext.ProductionRecords.AddRangeAsync(values.Select(x => x.ToModel()));
            await _dBContext.SaveChangesAsync();
            return values;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var productionRecord = await _dBContext.ProductionRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (productionRecord is not null)
            {
                _dBContext.ProductionRecords.Remove(productionRecord);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    internal async Task<ICollection<ProductionRecordDTO>> GetAllAsync(ProductionRecordFilter filter)
    {
        try
        {
            var productionRecords = await _dBContext.ProductionRecords.ToListAsync();
            var filtredProductionRecords = Filter(productionRecords, filter);
            return filtredProductionRecords.Select(x => x.ToDTO()).ToList();
        }
        catch
        {
            return null;
        }
    }

    private List<ProductionRecord> Filter(List<ProductionRecord> productionRecords, ProductionRecordFilter filter)
    {
        var filtredProductionRecords = productionRecords;
        if (filter.ProductId != null)
        {
            filtredProductionRecords = filtredProductionRecords.Where(x => x.ProductId == filter.ProductId).ToList();
        }
        if (filter.ActualQuantity != null)
        {
            filtredProductionRecords = filtredProductionRecords.Where(x => x.ActualQuantity == filter.ActualQuantity).ToList();
        }
        if (filter.EquipmentLineId != null)
        {
            filtredProductionRecords = filtredProductionRecords.Where(x => x.EquipmentLineId == filter.EquipmentLineId).ToList();
        }
        if (filter.SeriesNumber != null)
        {
            filtredProductionRecords = filtredProductionRecords.Where(x => x.SeriesNumber == filter.SeriesNumber).ToList();
        }
        if (filter.EmployeeId != null)
        {
            filtredProductionRecords = filtredProductionRecords
                .Where(x => x.OperatorDId == filter.EmployeeId 
                    || x.OperatorNKLId == filter.EmployeeId 
                    || x.SeniorOperatorId == filter.EmployeeId 
                    || x.PackerId == filter.EmployeeId )
                .ToList();
        }
        if (filter.StartTime != DateTime.MinValue)
        {
            filtredProductionRecords = filtredProductionRecords.Where(x => x.StartTime >= filter.StartTime).ToList();
        }
        if (filter.EndTime != DateTime.MinValue)
        {
            filtredProductionRecords = filtredProductionRecords.Where(x => x.EndTime <= filter.EndTime).ToList();
        }
        if (filter.Comments != null)
        {
            filtredProductionRecords = filtredProductionRecords.Where(x => x.Comments.Contains(filter.Comments)).ToList();
        }
        if (filter.Page  != null && filter.PageSize != null)
        {
            filtredProductionRecords = filtredProductionRecords.Skip(filter.Page.Value * filter.PageSize.Value).Take(filter.PageSize.Value).ToList();
        }
        return filtredProductionRecords;
    }

    internal async Task<int> GetPageCount(int pageSize)
    {
        var totalCount = await _dBContext.ProductionRecords.CountAsync();
        return (totalCount + pageSize - 1) / pageSize;
    }

    internal async Task<ProductionRecordDTO> GetAsync(int id)
    {
        var productionRecord = await _dBContext.ProductionRecords.FirstOrDefaultAsync(x => x.Id == id);
        return productionRecord == null ? null : productionRecord.ToDTO();
    }

    internal async Task<ProductionRecordDTO> UpdateAsync(ProductionRecordDTO value)
    {
        try
        {
            _dBContext.ProductionRecords.Update(value.ToModel());
            await _dBContext.SaveChangesAsync();
            return value;
        }
        catch
        {
            return null;
        }
    }
}