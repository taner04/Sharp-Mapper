using Sharp_Mapper.Mapper.Data_Transformer;

namespace Mapper_Units.Test_Objects.Numeric.Double
{
    internal class DoubleModelDto
    {
        [MapNumerics("FirstNumber", "SecondNumber")]
        public double Result { get; set; }
    }
}
