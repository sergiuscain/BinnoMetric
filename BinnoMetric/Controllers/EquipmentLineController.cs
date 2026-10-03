using BinnoMetric.DataBase.Models;
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
    [HttpGet("GetLines")]
    public async Task<ActionResult<List<EquipmentLine>>> GetLinesAsync()
    {
        return await _equipmentLineService.GetLinesAsync();
    }
    [HttpGet("GetLine")]
    public async Task<ActionResult<EquipmentLine>> GetLineAsync(int id)
    {
        var line = await _equipmentLineService.GetLineAsync(id);

        return line != null ? line : NotFound();
    }

}
