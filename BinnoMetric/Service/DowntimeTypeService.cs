using BinnoMetric.DataBase;
using BinnoMetric.DTO;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;

public class DowntimeTypeService
{
    private readonly BinnoDBContext _dbContext;
    public DowntimeTypeService(BinnoDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    internal async Task<DowntimeTypeDTO> AddAsync(DowntimeTypeDTO value)
    {
        try
        {
            await _dbContext.DowntimeTypes.AddAsync(value.ToModel());
            await _dbContext.SaveChangesAsync();
            return value;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<ICollection<DowntimeTypeDTO>> AddRangeAsync(ICollection<DowntimeTypeDTO> values)
    {
        try
        {
            await _dbContext.DowntimeTypes.AddRangeAsync(values.Select(x => x.ToModel()));
            await _dbContext.SaveChangesAsync();
            return values;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<bool> DeleteAsync(DowntimeTypeDTO value)
    {
        try
        {
            var downtimeType = await _dbContext.DowntimeTypes.
                FirstOrDefaultAsync(x => x.Id == value.Id);
            if (downtimeType is not null)
            {
                _dbContext.DowntimeTypes.Remove(downtimeType);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    internal async Task<ICollection<DowntimeTypeDTO>> GetAllAsync()
    {
        var downtimeTypes = await _dbContext.DowntimeTypes.ToListAsync();
        return downtimeTypes.Select(x => x.ToDTO()).ToList();
    }

    internal async Task<DowntimeTypeDTO> GetAsync(int id)
    {
        var downtimeType = await _dbContext.DowntimeTypes.FirstOrDefaultAsync(x => x.Id == id);
        return downtimeType == null ? null : downtimeType.ToDTO();
    }

    internal async Task<DowntimeTypeDTO> UpdateAsync(DowntimeTypeDTO value)
    {
        try
        {
            _dbContext.DowntimeTypes.Update(value.ToModel());
            await _dbContext.SaveChangesAsync();
            return value;
        }
        catch
        {
            return null;
        }
    }
}