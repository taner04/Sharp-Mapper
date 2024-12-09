using Sharp_Mapper.Interface.Unit;

namespace Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Double
{
    internal class DoubleSubtract : INumericUnit<double>
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public static DoubleSubtract GetTestObject()
        {
            return new DoubleSubtract
            {
                FirstNumber = 10.5,
                SecondNumber = 5.5
            };
        }
    }
}
