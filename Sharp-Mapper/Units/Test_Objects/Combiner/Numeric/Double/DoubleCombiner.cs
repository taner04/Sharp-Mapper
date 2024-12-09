using Sharp_Mapper.Interface.Unit;

namespace Sharp_Mapper.Units.Test_Objects.Combiner.Numeric.Double
{
    internal class DoubleCombiner : INumericUnit<double>
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public static DoubleCombiner GetTestObject()
        {
            return new DoubleCombiner
            {
                FirstNumber = 1.5,
                SecondNumber = 2.5
            };
        }
    }
}
