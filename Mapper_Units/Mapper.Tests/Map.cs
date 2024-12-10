using Mapper_Units.Test_Objects;
using Sharp_Mapper.Mapper;

namespace Mapper.Units.Mapper.Tests
{
    public class Map
    {
        [Fact]
        public void MapperMap_EmployeeToEmployeeDto_Sucess()
        {
            // Arrange
            var employee = Employee.GetTestObject();
            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            var mapperResponse = mapper.Map(employee);
            // Assert
            Assert.Equal(employee.Id, mapperResponse.Value.Id);
        }
    }
}
