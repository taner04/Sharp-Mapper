using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Combiner.Numeric.Int
{
    internal class IntCombinerDto
    {
        [MapperCombineNumbers("FirstNumber", "SecondNumber")]
        public int Result { get; set; }
    }
}
