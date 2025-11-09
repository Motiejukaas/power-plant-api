using Microsoft.EntityFrameworkCore;
using PowerPlantApi.Models;

namespace PowerPlantApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }
    
    public DbSet<PowerPlant> PowerPlants {  get; set; }
}