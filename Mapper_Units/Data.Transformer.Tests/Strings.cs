using Mapper.Units.Test.Objects.String;
using Mapper_Units.Test_Objects.String;
using Sharp_Mapper.Mapper;

namespace Mapper.Units.Data.Transformer.Tests
{
    public class Strings
    {
        [Fact]
        public void Combine_TwoStrings_Success()
        {
            // Arrange
            var stringModel = StringModel.GetTestObject("John", "Doe");

            var mapper = new Mapper<StringModelDto, StringModel>();
            // Act
            var mapperResponse = mapper.Map(stringModel);
            // Assert
            Assert.Equal("John Doe", mapperResponse.Value.Result);
        }
    }
}
