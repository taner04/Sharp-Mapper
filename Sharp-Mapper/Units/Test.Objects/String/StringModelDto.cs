using Sharp_Mapper.Mapper.Attributes;

namespace Sharp_Mapper.Units.Test.Objects.String;

internal class StringModelDto
{
    [MapStrings("Value1", "Value2")]
    public string Result { get; set; }
}