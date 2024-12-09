using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.String;

internal class StringModelDto
{
    [MapperCombineString("Value1", "Value2")]
    public string Result { get; set; }
}