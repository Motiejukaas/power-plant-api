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

    public async Task<IEnumerable<PowerPlantResponseDto>> GetAllAsync(string? owner = null, int pageNumber = 1, int pageSize = 5)
    {
        var powerPlants = await _powerPlantRepository.GetAllAsync(owner, pageNumber, pageSize);
        return powerPlants.Select(EntityToDto);
    }

    public async Task<PowerPlantResponseDto> CreateAsync(PowerPlantRequestDto powerPlantRequestDto)
    {
        var createdPowerPlant = await _powerPlantRepository.CreateAsync(DtoToEntity(powerPlantRequestDto));
        return EntityToDto(createdPowerPlant);
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

    private static PowerPlant DtoToEntity(PowerPlantRequestDto dto)
    {
        return new PowerPlant
        {
            Owner = dto.Owner,
            Power = dto.Power,
            ValidFrom = dto.ValidFrom,
            ValidTo = dto.ValidTo
        };
    }
}