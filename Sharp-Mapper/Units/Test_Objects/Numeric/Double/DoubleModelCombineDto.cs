using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Numeric.Double;

internal class DoubleModelCombineDto
{
    [MapperCombineNumbers("FirstNumber", "SecondNumber")]
    public double Result { get; set; }
}