using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper.Attributes;

/// <summary>
///     Attribute to combine two numeric properties of a source object.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class MapNumerics(string value1, string value2) : Attribute, IDataTransformer
{
    public string PropertyName1 { get; set; } = value1;
    public string PropertyName2 { get; set; } = value2;

    /// <summary>
    ///     Combines the values of the specified properties from the source object.
    /// </summary>
    /// <param name="source">The source object containing the properties to combine.</param>
    /// <param name="mappableObject"></param>
    /// <param name="value"></param>
    /// <returns>The combined value of the specified properties, or the default value if the properties are not found or null.</returns>
    public ErrorType Combine<TDestination>(PropertyInfo[] source, TDestination mappableObject, out object value)
    {
        var combinerValues = new object[2];

        foreach (var sourceProperty in source)
        {
            if (sourceProperty.Name == PropertyName1)
            {
                combinerValues[0] = sourceProperty.GetValue(mappableObject)!;
            }
            if (sourceProperty.Name == PropertyName2)
            {
                combinerValues[1] = sourceProperty.GetValue(mappableObject)!;
            }
        }

        if ((source[0].Equals(null) || source[1].Equals(null)))
        {
            value = default!;
            return ErrorType.CombinePropEmpty;
        }

        value = (dynamic)combinerValues[0] + (dynamic)combinerValues[1];
        return ErrorType.Success;
    }
}