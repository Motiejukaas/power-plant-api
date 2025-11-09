using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlantApi.Models;

public class PowerPlant
{
    public int Id { get; set; }
    public string Owner { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,1)")]
    public decimal Power { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}