using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerPlantApi.Data;
using PowerPlantApi.Interfaces;
using PowerPlantApi.Models;

namespace PowerPlantApi.Repository;

public class PowerPlantRepository : IPowerPlantRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public PowerPlantRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PowerPlant>> GetAllAsync(string? owner = null)
    {
        IQueryable<PowerPlant> query = _dbContext.PowerPlants.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(owner))
        {
            var pattern = $"%{owner}%";
            query = query.Where(p => EF.Functions.Like(p.Owner, pattern));
        }

        return await query.ToListAsync();
    }
}