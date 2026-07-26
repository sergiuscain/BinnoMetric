using BinnoMetric.Abstractions;
using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DowntimeTypeController : 
    ControllerBase, ICanAdd<DowntimeTypeDTO>, 
    ICanGet<DowntimeTypeDTO>, 
    ICanUpdate<DowntimeTypeDTO>, 
    ICanDelete<DowntimeTypeDTO>
{
    private readonly DowntimeTypeService _downtimeTypeService;
    public DowntimeTypeController(DowntimeTypeService downtimeTypeService)
    {
        _downtimeTypeService = downtimeTypeService;
    }
    [HttpDelete("DeleteDowntimeType")]
    public async Task<bool> DeleteAsync(DowntimeTypeDTO value)
    {
        return await _downtimeTypeService.DeleteAsync(value);
    }
    [HttpPut("UpdateDowntimeType")]
    public async Task<DowntimeTypeDTO> UpdateAsync(DowntimeTypeDTO value)
    {
        return await _downtimeTypeService.UpdateAsync(value);
    }
    [HttpPost("AddDowntimeType")]
    public async Task<DowntimeTypeDTO> AddAsync(DowntimeTypeDTO value)
    {
        return await _downtimeTypeService.AddAsync(value);
    }
    [HttpPost("AddDowntimeTypes")]
    public async Task<ICollection<DowntimeTypeDTO>> AddRangeAsync(ICollection<DowntimeTypeDTO> values)
    {
        return await _downtimeTypeService.AddRangeAsync(values);
    }
    [HttpGet("GetDowntimeType")]
    public async Task<DowntimeTypeDTO> GetAsync(int id)
    {
        return await _downtimeTypeService.GetAsync(id);
    }
    [HttpGet("GetDowntimeTypes")]
    public async Task<ICollection<DowntimeTypeDTO>> GetAllAsync()
    {
        return await _downtimeTypeService.GetAllAsync();
    }
}
