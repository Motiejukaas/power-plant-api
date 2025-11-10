using Microsoft.AspNetCore.Mvc;
using PowerPlantApi.Interfaces;

namespace PowerPlantApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PowerPlantController : ControllerBase
{
    private readonly IPowerPlantService  _powerPlantService;
    
    public PowerPlantController(IPowerPlantService powerPlantService)
    {
        _powerPlantService = powerPlantService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string ?owner = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
    {
        var powerPlants = await _powerPlantService.GetAllAsync(owner, pageNumber, pageSize);
        
        return Ok(powerPlants);
    }
}