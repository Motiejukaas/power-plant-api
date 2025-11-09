using PowerPlantApi.Models;

namespace PowerPlantApi.Interfaces;

public interface IPowerPlantRepository
{
    Task<IEnumerable<PowerPlant>> GetAllAsync(string? owner = null);
}