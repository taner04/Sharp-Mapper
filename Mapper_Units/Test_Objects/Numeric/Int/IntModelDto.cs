using Sharp_Mapper.Mapper.Data_Transformer;

namespace Mapper_Units.Test_Objects.Numeric.Int
{
    internal class IntModelDto
    {
        [MapNumerics("FirstNumber", "SecondNumber")]
        public int Result { get; set; }
    }
}
