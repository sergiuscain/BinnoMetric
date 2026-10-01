using BinnoMetric.DataBase;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;

public class EquipmentLineService
{
    private readonly BinnoDBContext _dbContext;
    public EquipmentLineService(BinnoDBContext context)
    {
        _dbContext = context;
    }
    public async Task<List<EquipmentLine>> GetLinesAsync()
    {
        var lines = await _dbContext.EquipmentLines.ToListAsync();
        return lines;
    }

    public async Task<EquipmentLine> GetLineAsync(int id)
    {
        var line = await _dbContext.EquipmentLines.FindAsync(id);
        return line;
    }
}
