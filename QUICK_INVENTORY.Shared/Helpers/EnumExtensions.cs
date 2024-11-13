using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace QUICK_INVENTORY.Shared.Helpers;

public static class EnumExtensions
{
    public static bool TryConvertToEnum<T>(this int value, out T? result) where T : Enum
    {
        result = default;

        try
        {
            bool valueExists = Enum.IsDefined(typeof(T), value);

            if (valueExists)
            {
                result = (T)Enum.ToObject(typeof(T), value);
            }

            return valueExists;
        }
        catch
        {
            return false;
        }
    }

    public static bool TryConvertToEnum<T>(this string name, out T? enumValue) where T : Enum
    {
        enumValue = default;

        try
        {
            Type type = typeof(T);

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == name)
                    {
                        enumValue = (T?)field.GetValue(null);

                        return true;
                    }
                }

                if (field.Name == name)
                {
                    enumValue = (T?)field.GetValue(null);

                    return true;
                }
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString()).First()
            .GetCustomAttribute<DisplayAttribute>()?
            .Name ?? enumValue.ToString();
    }

    public static string GetDisplayShortName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString()).First()
            .GetCustomAttribute<DisplayAttribute>()?
            .ShortName ?? enumValue.ToString();
    }

    public static string GetDisplayDescription(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString()).First()
            .GetCustomAttribute<DisplayAttribute>()?
            .Description ?? enumValue.ToString();
    }
}
