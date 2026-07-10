using BinnoMetric.Abstractions;
using BinnoMetric.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionRecordsController : ControllerBase, ICanAdd<ProductionRecord>, ICanGet<ProductionRecord>, ICanUpdate<ProductionRecord>, ICanDelete<ProductionRecord>
    {
        public Task<ProductionRecord> AddAsync(ProductionRecord value)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductionRecord>> AddRangeAsync(ICollection<ProductionRecord> values)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CanDeleteAsync(ProductionRecord value)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductionRecord>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductionRecord> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductionRecord> UpdateAsync(ProductionRecord value)
        {
            throw new NotImplementedException();
        }
    }
}
