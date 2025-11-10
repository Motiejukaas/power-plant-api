using System.ComponentModel.DataAnnotations;
using PowerPlantApi.Dtos;
using Xunit.Abstractions;

namespace Tests;

public class PowerPlantRequestDtoValidationTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PowerPlantRequestDtoValidationTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private static IList<ValidationResult> Validate(PowerPlantRequestDto dto)
    {
        var ctx = new ValidationContext(dto);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(dto, ctx, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void Owner_Whitespace_ProducesWhitespaceError()
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "   ",
            Power = 10,
            ValidFrom = new DateOnly(2025, 11, 10)
        };
        var results = Validate(dto);
        Assert.Contains(results, r => r.ErrorMessage == "Owner must not be empty or whitespace.");
    }

    [Fact]
    public void Owner_SingleWord_FailsTwoWordsRule()
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "Jonas",
            Power = 10,
            ValidFrom = new DateOnly(2025, 11, 10)
        };
        var results = Validate(dto);
        Assert.Contains(results, r => r.ErrorMessage == "Owner must consist of two words (text-only characters) separated by a space.");
    }
    
    [Fact]
    public void Owner_TwoWordsWithMultipleWhitespaces_FailsTwoWordsRule()
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "Jonas      Jonaitis",
            Power = 10,
            ValidFrom = new DateOnly(2025, 11, 10)
        };
        var results = Validate(dto);
        Assert.Contains(results, r => r.ErrorMessage == "Owner must consist of two words (text-only characters) separated by a space.");
    }

    [Fact]
    public void Owner_TwoWordsWithAccents_Passes()
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "Ona Petraitė",
            Power = 10.1m,
            ValidFrom = new DateOnly(2025, 11, 10)
        };
        var results = Validate(dto);
        Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(dto.Owner)));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(201)]
    public void Power_OutOfRange_Fails(decimal power)
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "Jonas Jonaitis",
            Power = power,
            ValidFrom = new DateOnly(2025, 11, 10)
        };
        var results = Validate(dto);
        Assert.Contains(results, r => r.ErrorMessage!.Contains("between 0 and 200"));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(200)]
    public void Power_Boundaries_Pass(decimal power)
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "Jonas Jonaitis",
            Power = power,
            ValidFrom = new DateOnly(2025, 11, 10)
        };
        var results = Validate(dto);
        Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(dto.Power)));
    }

    [Fact]
    public void ValidTo_BeforeValidFrom_Fails()
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "Jonas Jonaitis",
            Power = 10.3m,
            ValidFrom = new DateOnly(2025, 11, 10),
            ValidTo = new DateOnly(2025, 11, 09)
        };
        var results = Validate(dto);
        Assert.Contains(results, r => r.ErrorMessage == "validTo must be on or after validFrom");
    }

    [Fact]
    public void AllValid_NoErrors()
    {
        var dto = new PowerPlantRequestDto
        {
            Owner = "Jonas Jonaitis",
            Power = 50.1m,
            ValidFrom = new DateOnly(2025, 11, 10),
            ValidTo = new DateOnly(2025, 11, 10)
        };
        var results = Validate(dto);
        Assert.Empty(results);
    }
}