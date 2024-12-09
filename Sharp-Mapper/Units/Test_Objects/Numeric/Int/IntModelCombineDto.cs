using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Numeric.Int;

internal class IntModelCombineDto
{
    [MapperCombineNumbers("FirstNumber", "SecondNumber")]
    public int Result { get; set; }
}