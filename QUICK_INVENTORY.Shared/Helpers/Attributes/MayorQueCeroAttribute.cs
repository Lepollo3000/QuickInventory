using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QUICK_INVENTORY.Shared.Helpers.Attributes;

public class MayorQueCeroAttribute : ValidationAttribute
{
    public new string? ErrorMessage { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        PropertyInfo? currentProperty = validationContext.ObjectType
            .GetProperty(validationContext.MemberName ?? string.Empty);

        if (currentProperty != null)
        {
            int currentValue = value as int? ?? default;

            if (currentValue <= 0)
            {
                string currentPropertyDisplay = currentProperty.GetDisplayName();

                return new ValidationResult(ErrorMessage ??=
                        $"El campo '{currentPropertyDisplay}' debe ser mayor a 0.",
                    [validationContext.MemberName ?? string.Empty]);
            }
        }

        return ValidationResult.Success;
    }
}
