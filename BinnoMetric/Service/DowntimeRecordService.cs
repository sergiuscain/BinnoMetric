using BinnoMetric.DataBase;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;

public class DowntimeRecordService
{
    private readonly BinnoDBContext _dbContext;
    public DowntimeRecordService(BinnoDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    internal async Task<DowntimeRecordDTO> AddAsync(DowntimeRecordDTO value)
    {
        try
        {
            await _dbContext.DowntimeRecords.AddAsync(value.ToModel());
            await _dbContext.SaveChangesAsync();
            return value;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<ICollection<DowntimeRecordDTO>> AddRangeAsync(ICollection<DowntimeRecordDTO> values)
    {
        try
        {
            await _dbContext.DowntimeRecords.AddRangeAsync(values.Select(x => x.ToModel()));
            await _dbContext.SaveChangesAsync();
            return values;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<bool> DeleteAsync(DowntimeRecordDTO value)
    {
        try
        {
            _dbContext.DowntimeRecords.Remove(value.ToModel());
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal async Task<ICollection<DowntimeRecordDTO>> GetAllAsync()
    {
        try
        {
            var downtimeRecord = await _dbContext.DowntimeRecords.ToListAsync();
            return downtimeRecord.Select(x => x.ToDTO()).ToList();
        }
        catch
        {
            return null;
        }
    }

    internal async Task<DowntimeRecordDTO> GetAsync(int id)
    {
        var downtimeRecord = await _dbContext.DowntimeRecords.FirstOrDefaultAsync(x => x.Id == id);
        return downtimeRecord == null ? null : downtimeRecord.ToDTO();
    }

    internal async Task<DowntimeRecordDTO> UpdateAsync(DowntimeRecordDTO value)
    {
        try
        {
            _dbContext.DowntimeRecords.Update(value.ToModel());
            await _dbContext.SaveChangesAsync();
            return value;
        }
        catch
        {
            return null;
        }
    }
}