using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Data_Transformer;

/// <summary>
///     Attribute to combine two numeric properties of a source object.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class MapNumerics(string value1, string value2) : Attribute, IDataTransformer
{
    public string PropertyName1 { get; set; } = value1;
    public string PropertyName2 { get; set; } = value2;

    /// <summary>
    ///     Combines the values of the specified properties from the source object.
    /// </summary>
    /// <param name="source">The source object containing the properties to combine.</param>
    /// <returns>The combined value of the specified properties, or the default value if the properties are not found or null.</returns>
    public object Combine(object[]? source)
    {
        if (source != null && (source[0].Equals(null) || source[1].Equals(null)))
            return default!;
        return (dynamic)source[0] + (dynamic)source[1];
    }
}