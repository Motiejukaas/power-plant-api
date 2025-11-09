namespace PowerPlantApi.Dtos;

public class PowerPlantResponseDto
{
    public int Id { get; set; }
    public string Owner { get; set; } = string.Empty;
    public decimal Power { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}