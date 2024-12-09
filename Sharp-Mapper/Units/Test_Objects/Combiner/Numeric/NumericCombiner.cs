namespace Sharp_Mapper.Units.Test_Objects.Combiner.Numeric_Combiner
{
    internal class NumericCombiner
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public static NumericCombiner GetTestObject()
        {
            return new NumericCombiner
            {
                FirstNumber = 1,
                SecondNumber = 2
            };
        }
    }
}
