namespace Mapper.Units.Test.Objects.Numeric.Implementation
{
    internal class ByteModel : NumericBase<ByteModel, byte>
    {
        public override ByteModel GetTestObject(byte nr1, byte nr2)
        {
            return new ByteModel
            {
                FirstNumber = nr1,
                SecondNumber = nr2
            };
        }
    }
}
