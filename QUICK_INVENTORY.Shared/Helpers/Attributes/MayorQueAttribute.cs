using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QUICK_INVENTORY.Shared.Helpers.Attributes;

public class MayorQueAttribute(string comparisonPropertyName) : ValidationAttribute
{
    public new string? ErrorMessage { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        PropertyInfo? currentProperty = validationContext.ObjectType
            .GetProperty(validationContext.MemberName ?? string.Empty);

        PropertyInfo? comparisonProperty = validationContext.ObjectType
            .GetProperty(comparisonPropertyName);

        if (comparisonProperty != null
        && currentProperty != null)
        {
            int currentValue = value as int? ?? default;

            int comparisonValue = comparisonProperty
                .GetValue(validationContext.ObjectInstance) as int? ?? default;

            if (currentValue <= comparisonValue)
            {
                string currentPropertyDisplay = currentProperty.GetDisplayName();

                string comparisonPropertyDisplay = comparisonProperty.GetDisplayName();

                return new ValidationResult(ErrorMessage ??=
                        $"El campo '{currentPropertyDisplay}' debe ser mayor que el campo '{comparisonPropertyDisplay}'.",
                    [validationContext.MemberName ?? string.Empty]);
            }
        }

        return ValidationResult.Success;
    }
}
