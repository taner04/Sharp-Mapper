using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Subtract_Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class MapperSubtract(string propertyName1, string propertyName2) : Attribute, ISubtract
{
    public object PropertyName1 { get; set; } = propertyName1;
    public object PropertyName2 { get; set; } = propertyName2;

    public object Combine(object[]? source)
    {
        if (source?[0] == null || source?[1] == null) return default!;
        return (dynamic)source[0] - (dynamic)source[1];
    }
}