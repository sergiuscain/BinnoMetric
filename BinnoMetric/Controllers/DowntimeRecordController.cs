using BinnoMetric.Abstractions;
using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DowntimeRecordController: 
    ControllerBase, 
    ICanAdd<DowntimeRecordDTO>, 
    ICanGet<DowntimeRecordDTO>, 
    ICanUpdate<DowntimeRecordDTO>, 
    ICanDelete<DowntimeRecordDTO>
{
    private readonly DowntimeRecordService _downtimeRecordService;
    public DowntimeRecordController(DowntimeRecordService downtimeRecordService)
    {
        _downtimeRecordService = downtimeRecordService;
    }

    [HttpPost("AddDowntimeRecord")]
    public async Task<DowntimeRecordDTO> AddAsync(DowntimeRecordDTO value)
    {
        return await _downtimeRecordService.AddAsync(value);
    }
    [HttpPost("AddDowntimeRecords")]
    public async Task<ICollection<DowntimeRecordDTO>> AddRangeAsync(ICollection<DowntimeRecordDTO> values)
    {
        return await _downtimeRecordService.AddRangeAsync(values);
    }
    [HttpGet("GetDowntimeRecord")]
    public async Task<DowntimeRecordDTO> GetAsync(int id)
    {
        return await _downtimeRecordService.GetAsync(id);
    }
    [HttpGet("GetDowntimeRecords")]
    public async Task<ICollection<DowntimeRecordDTO>> GetAllAsync()
    {
        return await _downtimeRecordService.GetAllAsync();
    }
    [HttpPut("UpdateDowntimeRecord")]
    public async Task<DowntimeRecordDTO> UpdateAsync(DowntimeRecordDTO value)
    {
        return await _downtimeRecordService.UpdateAsync(value);
    }
    [HttpDelete("DeleteDowntimeRecord")]
    public async Task<bool> DeleteAsync(DowntimeRecordDTO value)
    {
        return await _downtimeRecordService.DeleteAsync(value);
    }
}
