using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DowntimeController: 
        ControllerBase, 
        ICanAdd<DowntimeRecordDTO>, 
        ICanGet<DowntimeRecordDTO>, 
        ICanUpdate<DowntimeRecordDTO>, 
        ICanDelete<DowntimeRecordDTO>, 
        ICanAdd<DowntimeTypeDTO>, 
        ICanGet<DowntimeTypeDTO>, 
        ICanUpdate<DowntimeTypeDTO>, 
        ICanDelete<DowntimeTypeDTO>
    {
        [HttpPost("AddDowntimeRecord")]
        public Task<DowntimeRecordDTO> AddAsync(DowntimeRecordDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddDowntimeRecords")]
        public Task<ICollection<DowntimeRecordDTO>> AddRangeAsync(ICollection<DowntimeRecordDTO> values)
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
        [HttpGet("GetDowntimeRecord")]
        public Task<DowntimeRecordDTO> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeRecords")]
        public Task<ICollection<DowntimeRecordDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeType")]
        Task<DowntimeTypeDTO> ICanGet<DowntimeTypeDTO>.GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeTypes")]
        Task<ICollection<DowntimeTypeDTO>> ICanGet<DowntimeTypeDTO>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateDowntimeRecord")]
        public Task<DowntimeRecordDTO> UpdateAsync(DowntimeRecordDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateDowntimeType")]
        public Task<DowntimeTypeDTO> UpdateAsync(DowntimeTypeDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteDowntimeRecord")]
        public Task<bool> DeleteAsync(DowntimeRecordDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteDowntimeType")]
        public Task<bool> DeleteAsync(DowntimeTypeDTO value)
        {
            throw new NotImplementedException();
        }
    }
}
