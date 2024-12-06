using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Sharp_Mapper.Result;

/// <summary>
/// Provides extension methods for handling errors.
/// </summary>
public static class ErrorExtension
{
    /// <summary>
    /// Gets the header description of the specified error type.
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
    /// Gets the description of the error based on the source and destination properties and the error type.
    /// </summary>
    /// <param name="sourceProp">The source property.</param>
    /// <param name="destinProp">The destination property.</param>
    /// <param name="errorType">The error type.</param>
    /// <returns>A string describing the error.</returns>
    public static string GetDescription(PropertyInfo sourceProp, PropertyInfo destinProp, ErrorType errorType)
    {
        if (errorType != ErrorType.Unknown)
        {
            var sb = new StringBuilder();
            sb.Append($"Map from {sourceProp.Name} to {destinProp.Name}");

            return sb.ToString();
        }

        return "Unknow Error";
    }
}
