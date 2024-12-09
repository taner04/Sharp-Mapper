using Sharp_Mapper.Mapper.Subtract_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Int
{
    internal class IntSubtractDto
    {
        [MapperSubtract("FirstNumber", "SecondNumber")]
        public int Result { get; set; }
    }
}
