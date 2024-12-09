using Sharp_Mapper.Mapper.Data_Transformer;

namespace Sharp_Mapper.Units.Test_Objects.Numeric.Int;

internal class IntModelCombineDto
{
    [MapNumerics("FirstNumber", "SecondNumber")]
    public int Result { get; set; }
}