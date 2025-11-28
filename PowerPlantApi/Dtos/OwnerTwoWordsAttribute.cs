using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PowerPlantApi.Dtos;

public sealed class OwnerTwoWordsAttribute : ValidationAttribute
{
    private static readonly Regex Pattern = new(@"^[A-Za-zÀ-ž]+ [A-Za-zÀ-ž]+$", RegexOptions.Compiled);

    public const string RequiredErrorMessage = "Owner must not be empty or whitespace.";

    public const string TwoWordsErrorMessage = "Owner must consist of two words (text-only characters) separated by a space.";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // to avoid having double error messages on null
        if (value is null)
        {
            return ValidationResult.Success; // implicit [Required] handles null
        }
        
        var s = value as string;
        if (string.IsNullOrWhiteSpace(s))
        {
            return new ValidationResult(RequiredErrorMessage);
        }
        
        return Pattern.IsMatch(s) ? ValidationResult.Success : new ValidationResult(TwoWordsErrorMessage);
    }
}