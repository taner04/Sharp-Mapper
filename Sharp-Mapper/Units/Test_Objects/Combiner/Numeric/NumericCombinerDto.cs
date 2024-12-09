using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Combiner.Numeric_Combiner
{
    internal class NumericCombinerDto
    {
        [MapperCombineNumbers("FirstNumber", "SecondNumber")]
        public int Result { get; set; }
    }
}
