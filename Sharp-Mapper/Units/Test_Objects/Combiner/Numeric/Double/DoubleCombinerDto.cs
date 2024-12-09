using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Combiner.Numeric.Double
{
    internal class DoubleCombinerDto
    {
        [MapperCombineNumbers(nameof(DoubleCombiner.FirstNumber), nameof(DoubleCombiner.SecondNumber))]
        public double Result { get; set; }
    }
}
