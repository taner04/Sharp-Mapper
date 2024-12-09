using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Sharp_Mapper.Result;

/// <summary>
///     Provides extension methods for handling errors.
/// </summary>
public static class ErrorExtension
{
    /// <summary>
    ///     Gets the header description of the specified error type.
    /// </summary>
    /// <param name="errorType">The error type.</param>
    /// <returns>The description of the error type if available; otherwise, the error type as a string.</returns>
    public static string GetHeader(ErrorType errorType)
    {
        var fi = errorType.GetType().GetField(errorType.ToString());
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : errorType.ToString();
    }

    /// <summary>
    ///     Gets the description of the error based on the source and destination properties and the error type.
    /// </summary>
    /// <param name="sourceProp">The source property.</param>
    /// <param name="destinProp">The destination property.</param>
    /// <param name="errorType">The error type.</param>
    /// <returns>A string describing the error.</returns>
    public static string GetDescription(PropertyInfo sourceProp, PropertyInfo destinProp, ErrorType errorType)
    {
        if (errorType == ErrorType.Unknown)
            return "Unknown Error";

        var sb = new StringBuilder();
        sb.Append($"Couldn't map from prop. {sourceProp?.Name} ({GetPropertyText(sourceProp)}) to ");
        sb.Append($"prop. {destinProp?.Name} ({GetPropertyText(destinProp)})");
        return sb.ToString();
    }

    /// <summary>
    ///     Gets the text representation of the specified property.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <returns>A string representing the property.</returns>
    private static string GetPropertyText(PropertyInfo? propertyInfo)
    {
        var propertyClassName = propertyInfo?.DeclaringType?.Name ?? "Unknown class";
        var propertyPropertyType = propertyInfo?.PropertyType;
        var propertyTypeName = propertyPropertyType?.Name ?? "Unknown type";
        //var isNullable = Nullable.GetUnderlyingType(propertyPropertyType) != null;
        //return $"{propertyClassName}, {propertyTypeName}{(isNullable ? " (nullable)" : "")}";
        return $"{propertyClassName}, {propertyTypeName}";
    }
}