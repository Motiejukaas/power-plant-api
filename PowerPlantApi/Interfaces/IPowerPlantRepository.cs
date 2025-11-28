using PowerPlantApi.Models;

namespace PowerPlantApi.Interfaces;

public interface IPowerPlantRepository
{
    Task<IEnumerable<PowerPlant>> GetAllAsync(List<string>? owner = null, int pageNumber = 1, int pageSize = 5);
    Task<PowerPlant> CreateAsync(PowerPlant powerPlant);
}