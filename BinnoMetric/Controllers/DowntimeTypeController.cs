using BinnoMetric.Abstractions;
using BinnoMetric.DTO;
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
    [HttpDelete("DeleteDowntimeType")]
    public Task<bool> DeleteAsync(DowntimeTypeDTO value)
    {
        throw new NotImplementedException();
    }
    [HttpPut("UpdateDowntimeType")]
    public Task<DowntimeTypeDTO> UpdateAsync(DowntimeTypeDTO value)
    {
        throw new NotImplementedException();
    }
    [HttpPost("AddDowntimeType")]
    public Task<DowntimeTypeDTO> AddAsync(DowntimeTypeDTO value)
    {
        throw new NotImplementedException();
    }
    [HttpPost("AddDowntimeTypes")]
    public Task<ICollection<DowntimeTypeDTO>> AddRangeAsync(ICollection<DowntimeTypeDTO> values)
    {
        throw new NotImplementedException();
    }
    [HttpGet("GetDowntimeType")]
    public Task<DowntimeTypeDTO> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
    [HttpGet("GetDowntimeTypes")]
    public Task<ICollection<DowntimeTypeDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
