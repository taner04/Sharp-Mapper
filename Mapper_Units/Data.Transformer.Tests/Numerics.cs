using Mapper.Units.Test.Objects.Numeric;
using Mapper.Units.Test.Objects.Numeric.Implementation;
using Sharp_Mapper.Mapper;

namespace Mapper.Units.Data.Transformer.Tests
{
    public class Numerics
    {
        [Fact]
        public void Combine_TwoIntegers_Success()
        {
            // Arrange
            var intModle = new IntModel().GetTestObject(5,5);
            var mapper = new Mapper<NumericDto<int>, IntModel>();
            // Act
            var mapperResponse = mapper.Map(intModle);
            // Assert
            Assert.Equal(10, mapperResponse.Value.Result);
        }

        [Fact]
        public void Combine_TwoDoubles_Success()
        {
            // Arrange
            var doubleModel = new DoubleModel().GetTestObject(5.5, 5.5);
            var mapper = new Mapper<NumericDto<double>, DoubleModel>();
            // Act
            var mapperResponse = mapper.Map(doubleModel);
            // Assert
            Assert.Equal(11, mapperResponse.Value.Result);
        }

        [Fact]
        public void Combine_TwoBytes_Success()
        {
            // Arrange
            var byteModel = new ByteModel().GetTestObject(5, 5);
            var mapper = new Mapper<NumericDto<byte>, ByteModel>();
            // Act
            var mapperResponse = mapper.Map(byteModel);
            // Assert
            Assert.Equal(10, mapperResponse.Value.Result);
        }
    }
}
