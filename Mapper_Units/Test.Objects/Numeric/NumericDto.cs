using Sharp_Mapper.Mapper.Attributes;

namespace Mapper.Units.Test.Objects.Numeric
{
    internal class NumericDto<TType>
    {
        [MapNumerics("FirstNumber", "SecondNumber")]
        public TType Result { get; set; }
    }
}
