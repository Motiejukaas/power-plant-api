using PowerPlantApi.Dtos;
using PowerPlantApi.Interfaces;
using PowerPlantApi.Models;

namespace PowerPlantApi.Services;

public class PowerPlantService : IPowerPlantService
{
    private readonly IPowerPlantRepository _powerPlantRepository;
    
    public PowerPlantService(IPowerPlantRepository powerPlantRepository)
    {
        _powerPlantRepository = powerPlantRepository;
    }

    public async Task<IEnumerable<PowerPlantResponseDto>> GetAllAsync(string? owner = null)
    {
        var powerPlants = await _powerPlantRepository.GetAllAsync(owner);
        return powerPlants.Select(EntityToDto);
    }

    private static PowerPlantResponseDto EntityToDto(PowerPlant entity)
    {
        return new PowerPlantResponseDto
        {
            Id = entity.Id,
            Owner = entity.Owner,
            Power = entity.Power,
            ValidFrom = entity.ValidFrom,
            ValidTo = entity.ValidTo
        };
    }
}