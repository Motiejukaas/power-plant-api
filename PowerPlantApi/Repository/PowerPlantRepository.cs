using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<PowerPlant>> GetAllAsync(List<string>? owner = null, int pageNumber = 1, int pageSize = 5)
    {
        IQueryable<PowerPlant> query = _dbContext.PowerPlants.AsNoTracking();

        if (owner is not null)
        {
            foreach (var ownerWord in owner)
            {
                if (!string.IsNullOrWhiteSpace(ownerWord))
                {
                    var pattern = $"%{ownerWord}%";
                    query = query.Where(p => EF.Functions.Like(p.Owner, pattern));
                }
            }
        }
        
        var skipNumber = (pageNumber - 1) * pageSize;
        
        return await query.Skip(skipNumber).Take(pageSize).ToListAsync();
    }

    public async Task<PowerPlant> CreateAsync(PowerPlant powerPlant)
    {
        await _dbContext.PowerPlants.AddAsync(powerPlant);
        await _dbContext.SaveChangesAsync();
        return  powerPlant;
    }
}