namespace Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Double;

internal class DoubleModel
{
    public double FirstNumber { get; set; }
    public double SecondNumber { get; set; }

    public static DoubleModel GetTestObject(double nr1, double nr2)
    {
        return new DoubleModel
        {
            FirstNumber = nr1,
            SecondNumber = nr2
        };
    }
}