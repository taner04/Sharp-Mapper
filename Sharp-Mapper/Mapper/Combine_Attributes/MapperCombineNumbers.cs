using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Costum_Attributes;

/// <summary>
///     Attribute to combine two numeric properties of a source object.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class MapperCombineNumbers(object value1, object value2) : Attribute, ICombiner
{
    public object PropertyName1 { get; set; } = value1;
    public object PropertyName2 { get; set; } = value2;

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