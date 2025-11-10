using System.ComponentModel.DataAnnotations;

namespace PowerPlantApi.Dtos;

public class PowerPlantRequestDto : IValidatableObject
{
    [OwnerTwoWords]
    public string Owner { get; set; } = string.Empty;
    [Range(0, 200, ErrorMessage = "Power must be between 0 and 200")]
    public decimal Power { get; set; }
    [Required(ErrorMessage = "Valid from date is required")]
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ValidTo is not null && ValidTo < ValidFrom)
            yield return new ValidationResult("validTo must be on or after validFrom", [nameof(ValidTo)]);
    }
}