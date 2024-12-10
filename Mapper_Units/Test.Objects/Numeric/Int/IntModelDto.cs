using Sharp_Mapper.Mapper.Attributes;

namespace Mapper.Units.Test.Objects.Numeric.Int
{
    internal class IntModelDto
    {
        [MapNumerics("FirstNumber", "SecondNumber")]
        public int Result { get; set; }
    }
}
