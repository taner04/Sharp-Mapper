namespace Mapper.Units.Test.Objects.Numeric.Implementation
{
    internal class IntModel : NumericBase<IntModel, int>
    {
        public override IntModel GetTestObject(int nr1, int nr2)
        {
            return new IntModel
            {
                FirstNumber = nr1,
                SecondNumber = nr2
            };
        }
    }
}
