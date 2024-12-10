using Sharp_Mapper.Mapper.Attributes;

namespace Mapper.Units.Test.Objects.Numeric.Double
{
    internal class DoubleModelDto
    {
        [MapNumerics("FirstNumber", "SecondNumber")]
        public double Result { get; set; }
    }
}
