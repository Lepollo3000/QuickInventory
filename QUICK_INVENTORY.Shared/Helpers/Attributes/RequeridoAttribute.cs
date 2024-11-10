using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QUICK_INVENTORY.Shared.Helpers.Attributes;

public class RequeridoAttribute : ValidationAttribute
{
    public new string? ErrorMessage { get; set; }
    public bool PermitirStringsVacios { get; set; } = false;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        PropertyInfo? currentProperty = validationContext.ObjectType
            .GetProperty(validationContext.MemberName ?? string.Empty);

        if (currentProperty != null)
        {
            if (value == null)
            {
                return GetErrorMessage(property: currentProperty, validationContext: validationContext);
            }

            bool valueStringValid = PermitirStringsVacios
                || value is not string valueString
                || !string.IsNullOrEmpty(valueString);

            if (!valueStringValid)
            {
                return GetErrorMessage(property: currentProperty, validationContext: validationContext);
            }
        }

        return ValidationResult.Success;
    }

    private ValidationResult GetErrorMessage(PropertyInfo property, ValidationContext validationContext)
    {
        string propertyDisplay = property.GetDisplayName();

        return new ValidationResult(ErrorMessage ??=
                $"El campo '{propertyDisplay}' es requerido.",
            [validationContext.MemberName ?? string.Empty]);
    }
}
