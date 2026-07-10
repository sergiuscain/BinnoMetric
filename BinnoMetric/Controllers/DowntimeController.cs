using BinnoMetric.Abstractions;
using BinnoMetric.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DowntimeController : ControllerBase, ICanAdd<DowntimeRecord>, ICanGet<DowntimeRecord>, ICanUpdate<DowntimeRecord>, ICanDelete<DowntimeRecord>, ICanAdd<DowntimeType>, ICanGet<DowntimeType>, ICanUpdate<DowntimeType>, ICanDelete<DowntimeType>
    {
        [HttpPost("AddDowntimeRecord")]
        public Task<DowntimeRecord> AddAsync(DowntimeRecord value)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddDowntimeRecords")]
        public Task<ICollection<DowntimeRecord>> AddRangeAsync(ICollection<DowntimeRecord> values)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddDowntimeType")]
        public Task<DowntimeType> AddAsync(DowntimeType value)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddDowntimeTypes")]
        public Task<ICollection<DowntimeType>> AddRangeAsync(ICollection<DowntimeType> values)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeRecord")]
        public Task<DowntimeRecord> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeRecords")]
        public Task<ICollection<DowntimeRecord>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeType")]
        Task<DowntimeType> ICanGet<DowntimeType>.GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeTypes")]
        Task<ICollection<DowntimeType>> ICanGet<DowntimeType>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateDowntimeRecord")]
        public Task<DowntimeRecord> UpdateAsync(DowntimeRecord value)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateDowntimeType")]
        public Task<DowntimeType> UpdateAsync(DowntimeType value)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteDowntimeRecord")]
        public Task<bool> CanDeleteAsync(DowntimeRecord value)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteDowntimeType")]
        public Task<bool> CanDeleteAsync(DowntimeType value)
        {
            throw new NotImplementedException();
        }
    }
}
