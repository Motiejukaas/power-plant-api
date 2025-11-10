using PowerPlantApi.Models;

namespace PowerPlantApi.Interfaces;

public interface IPowerPlantRepository
{
    Task<IEnumerable<PowerPlant>> GetAllAsync(string? owner = null, int pageNumber = 1, int pageSize = 5);
}