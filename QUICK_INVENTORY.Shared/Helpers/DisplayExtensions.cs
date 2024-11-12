using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace QUICK_INVENTORY.Shared.Helpers;

public static class DisplayHelper<T> where T : class
{
    public static string GetPropertyDisplayName(Expression<Func<T, object>> propertyExpression)
    {
        var memberInfo = GetPropertyInformation(propertyExpression.Body)
            ?? throw new ArgumentException("No property reference expression was found.", nameof(propertyExpression));

        var attribute = memberInfo
            .GetAttribute<DisplayAttribute>(false);

        if (attribute == null)
        {
            return memberInfo.Name;
        }

        return attribute.Name ?? memberInfo.Name;
    }

    public static MemberInfo GetPropertyInformation(Expression propertyExpression)
    {
        Debug.Assert(propertyExpression != null, "propertyExpression != null");
        MemberExpression? memberExpr = propertyExpression as MemberExpression;

        if (memberExpr == null)
        {
            if (propertyExpression is UnaryExpression unaryExpr
            && unaryExpr.NodeType == ExpressionType.Convert)
            {
                memberExpr = unaryExpr.Operand as MemberExpression;
            }
        }

        if (memberExpr != null
        && memberExpr.Member.MemberType == MemberTypes.Property)
        {
            return memberExpr.Member;
        }

        return null!;
    }

}

public static class DisplayExtensions
{
    public static string GetDisplayName(this PropertyInfo property)
    {
        DisplayAttribute? attribute = property
            .GetCustomAttributes(typeof(DisplayAttribute), true)
            .FirstOrDefault() as DisplayAttribute;

        return attribute?.Name ?? property.Name;
    }

    /// <summary>
    /// Obtiene el nombre del atributo [Display] adjuntado a una propiedad dada.
    /// </summary>
    /// <returns></returns>
    public static string GetDisplayName<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
    {
        DisplayAttribute? attribute = model.GetDisplayAttribute(expression);

        return attribute?.Name ?? string.Empty;
    }

    /// <summary>
    /// Obtiene la descripción del atributo [Display] adjuntado a una propiedad dada.
    /// </summary>
    /// <returns></returns>
    public static string GetDisplayDescription<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
    {
        DisplayAttribute? attribute = model.GetDisplayAttribute(expression);

        return attribute?.Description ?? string.Empty;
    }

    /// <summary>
    /// Obtiene el atributo [Display] adjuntado a una propiedad dada
    /// </summary>
    /// <returns></returns>
    private static DisplayAttribute? GetDisplayAttribute<TModel, TProperty>(this TModel _, Expression<Func<TModel, TProperty>> expression)
    {
        Type type = typeof(TModel);

        MemberExpression memberExpression = (MemberExpression)expression.Body;
        string propertyName = memberExpression.Member is PropertyInfo
            ? memberExpression.Member.Name
            : null!;

        DisplayAttribute? attribute = type
            .GetProperty(propertyName)?
            .GetCustomAttributes(typeof(DisplayAttribute), true)
            .SingleOrDefault() as DisplayAttribute;

        if (attribute == null)
        {
            if (type
                .GetCustomAttributes(typeof(MetadataTypeAttribute), true)
                .FirstOrDefault() is MetadataTypeAttribute metadataType)
            {
                var property = metadataType.MetadataClassType.GetProperty(propertyName);

                if (property != null)
                {
                    attribute = property
                        .GetCustomAttributes(typeof(DisplayAttribute), true)
                        .SingleOrDefault() as DisplayAttribute;
                }
            }
        }

        return attribute;
    }

    public static T GetAttribute<T>(this MemberInfo member, bool isRequired)
    where T : Attribute
    {
        var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

        if (attribute == null && isRequired)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "The {0} attribute must be defined on member {1}",
                    typeof(T).Name,
                    member.Name));
        }

        return (T)attribute!;
    }
}
