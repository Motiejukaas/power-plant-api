using Microsoft.EntityFrameworkCore;
using PowerPlantApi.Models;

namespace PowerPlantApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PowerPlant>(entity =>
        {
            entity.ToTable("PowerPlants");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Owner)
                .IsRequired()
                .UseCollation("Latin1_General_100_CI_AI");
            entity.Property(p => p.Power).HasPrecision(18, 1);
            entity.Property(p => p.ValidFrom).IsRequired();
        });
    }

    public DbSet<PowerPlant> PowerPlants {  get; set; }
}