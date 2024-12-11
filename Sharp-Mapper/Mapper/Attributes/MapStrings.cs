using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper.Attributes;

/// <summary>
///     Attribute to combine two string properties of a source object.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class MapStrings(string value1, string value2) : Attribute, IDataTransformer
{
    public string PropertyName1 { get; } = value1;
    public string PropertyName2 { get; } = value2;

    /// <summary>
    ///     Combines the values of the specified properties from the source object.
    /// </summary>
    /// <typeparam name="TDestination">The type of the destination object.</typeparam>
    /// <param name="source">The source object containing the properties to combine.</param>
    /// <param name="mappableObject">The object to map the combined values to.</param>
    /// <param name="value">The combined value of the specified properties.</param>
    /// <returns>An <see cref="ErrorType"/> indicating the result of the combination.</returns>
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
            value = null;
            return default!;
        }

        value = string.Join(" ", combinerValues);
        return ErrorType.Success;
    }
}
