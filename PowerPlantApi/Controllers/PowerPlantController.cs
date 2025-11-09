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
    public async Task<IActionResult> GetAll([FromQuery] string ?owner = null)
    {
        var powerPlants = await _powerPlantService.GetAllAsync(owner);
        
        return Ok(powerPlants);
    }
}