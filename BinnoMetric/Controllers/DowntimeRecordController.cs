using BinnoMetric.Abstractions;
using BinnoMetric.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DowntimeRecordController: 
        ControllerBase, 
        ICanAdd<DowntimeRecordDTO>, 
        ICanGet<DowntimeRecordDTO>, 
        ICanUpdate<DowntimeRecordDTO>, 
        ICanDelete<DowntimeRecordDTO>
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
        [HttpGet("GetDowntimeRecord")]
        public Task<DowntimeRecordDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetDowntimeRecords")]
        public Task<ICollection<DowntimeRecordDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateDowntimeRecord")]
        public Task<DowntimeRecordDTO> UpdateAsync(DowntimeRecordDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteDowntimeRecord")]
        public Task<bool> DeleteAsync(DowntimeRecordDTO value)
        {
            throw new NotImplementedException();
        }
    }
}
