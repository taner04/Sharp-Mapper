using Sharp_Mapper.Mapper.Subtract_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Int;

internal class IntModelSubtractDto
{
    [MapperSubtract("FirstNumber", "SecondNumber")]
    public int Result { get; set; }
}