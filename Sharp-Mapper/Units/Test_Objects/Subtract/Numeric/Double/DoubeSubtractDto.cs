using Sharp_Mapper.Mapper.Subtract_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Double
{
    internal class DoubeSubtractDto
    {
        [MapperSubtract("FirstNumber", "SecondNumber")]
        public double Result { get; set; }
    }
}
