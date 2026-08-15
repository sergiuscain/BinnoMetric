using BinnoMetric.DataBase;
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

    internal async Task<ICollection<ProductionRecordDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var productionRecords = await _dBContext.ProductionRecords.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return productionRecords.Select(x => x.ToDTO()).ToList();
        }
        catch
        {
            return null;
        }
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