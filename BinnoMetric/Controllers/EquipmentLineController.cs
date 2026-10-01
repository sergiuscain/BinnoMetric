using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentLineController : Controller
{
    private readonly EquipmentLineService _equipmentLineService;
    public EquipmentLineController(EquipmentLineService equipmentLineService)
    {
        _equipmentLineService = equipmentLineService;
    }
    [HttpGet("GetLine")]
    public async Task<List<EquipmentLine>> GetLinesAsync()
    {
        return await _equipmentLineService.GetLinesAsync();
    }

}
