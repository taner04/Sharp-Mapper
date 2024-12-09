namespace Sharp_Mapper.Units.Test_Objects.Combiner.Numeric.Int
{
    internal class IntCombiner
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public static IntCombiner GetTestObject()
        {
            return new IntCombiner
            {
                FirstNumber = 1,
                SecondNumber = 2
            };
        }
    }
}
