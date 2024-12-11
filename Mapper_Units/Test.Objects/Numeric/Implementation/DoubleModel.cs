namespace Mapper.Units.Test.Objects.Numeric.Implementation
{
    internal class DoubleModel : NumericBase<DoubleModel, double>
    {
        public override DoubleModel GetTestObject(double nr1, double nr2)
        {
            return new DoubleModel
            {
                FirstNumber = nr1,
                SecondNumber = nr2
            };
        }
    }
}
