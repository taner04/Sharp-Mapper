using Sharp_Mapper.Interface.Unit;

namespace Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Int
{
    internal class IntSubtract : INumericUnit<int>
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public static IntSubtract GetTestObject()
        {
            return new IntSubtract
            {
                FirstNumber = 10,
                SecondNumber = 5
            };
        }
    }
}
