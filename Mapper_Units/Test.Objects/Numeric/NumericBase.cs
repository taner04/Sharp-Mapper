namespace Mapper.Units.Test.Objects.Numeric
{
    internal abstract class NumericBase<TCLass, TType>
    {
        public TType FirstNumber { get; set; }
        public TType SecondNumber { get; set; }

        public abstract TCLass GetTestObject(TType nr1, TType nr2);
    }
}
