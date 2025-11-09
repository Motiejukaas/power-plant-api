using System.ComponentModel.DataAnnotations;

namespace PowerPlantApi.Dtos;

public class PowerPlantRequestDto
{
    [Required]
    public string Owner { get; set; } = string.Empty;
    [Required]
    public decimal Power { get; set; }
    [Required]
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}