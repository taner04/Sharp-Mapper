namespace Mapper_Units.Test_Objects.Numeric.Int
{
    internal class IntModel
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public static IntModel GetTestObject(int nr1, int nr2)
        {
            return new IntModel
            {
                FirstNumber = nr1,
                SecondNumber = nr2
            };
        }
    }
}
