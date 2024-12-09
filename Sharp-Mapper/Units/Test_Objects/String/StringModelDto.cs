using Sharp_Mapper.Mapper.Data_Transformer;

namespace Sharp_Mapper.Units.Test_Objects.String;

internal class StringModelDto
{
    [MapStrings("Value1", "Value2")]
    public string Result { get; set; }
}