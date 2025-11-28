using PowerPlantApi.Dtos;

namespace PowerPlantApi.Interfaces;

public interface IPowerPlantService
{
    Task<IEnumerable<PowerPlantResponseDto>> GetAllAsync(List<string>? owner = null, int pageNumber = 1, int pageSize = 5);
    Task<PowerPlantResponseDto> CreateAsync(PowerPlantRequestDto powerPlantRequestDto);
}