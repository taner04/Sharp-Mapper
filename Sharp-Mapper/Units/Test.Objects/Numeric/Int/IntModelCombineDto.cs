using Sharp_Mapper.Mapper.Attributes;

namespace Sharp_Mapper.Units.Test.Objects.Numeric.Int;

internal class IntModelCombineDto
{
    [MapNumerics("FirstNumber", "SecondNumber")]
    public int Result { get; set; }
}