using Mapper_Units.Test_Objects;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Result;

namespace Mapper.Units.Mapper.Tests
{
    public class Map
    {
        [Fact]
        public void MapperMap_EmployeeToEmployeeDto_Success()
        {
            // Arrange
            var employee = Employee.GetTestObject();
            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            var mapperResponse = mapper.Map(employee);
            // Assert
            Assert.Equal(employee.Id, mapperResponse.Value.Id);
        }

        [Fact]
        public void MapperMapBack_EmployeeDtoToEmployee_Success()
        {
            // Arrange
            var employeeDto = EmployeeDto.GetTestObject();
            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            var mapperResponse = mapper.MapBack(employeeDto);
            // Assert
            Assert.Equal(employeeDto.Id, mapperResponse.Value.Id);
        }

        [Fact]
        public void MapperUpdate_EmployeeDto_Success()
        {
            // Arrange
            var employee = Employee.GetTestObject();
            var employeeDto = EmployeeDto.GetTestObject();

            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            mapper.Update(employeeDto, ref employee);
            // Assert
            Assert.Equal(employeeDto.Firstname, employee.Firstname);
        }

        [Fact]
        public void MapperUpdate_Employee_Success()
        {
            // Arrange
            var employee = Employee.GetTestObject();
            var employeeDto = EmployeeDto.GetTestObject();

            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            mapper.Update(employee, ref employeeDto);
            // Assert
            Assert.Equal(employee.Firstname, employeeDto.Firstname);
        }

        [Fact]
        public void MapperMap_MapRequiredProperty_Success()
        {
            // Arrange
            var employee = Employee.GetTestObject();

            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            var mapperResponse = mapper.Map(employee);
            // Assert
            Assert.Equal(employee.Id, mapperResponse.Value.Id);
        }

        [Fact]
        public void MapperMap_MapRequiredProperty_Failure()
        {
            // Arrange
            var employee = Employee.GetTestObject();
            employee.Firstname = null!;

            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            var mapperResponse = mapper.Map(employee);
            // Assert
            Assert.Equal(ErrorType.RequieredProperty, mapperResponse.Error?.ErrorType);
        }

        [Fact]
        public void Mapper_Dispose_Success()
        {
            // Arrange
            var employee = Employee.GetTestObject();
            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            mapper.Dispose();
            // Assert
            Assert.True(mapper.IsDisposed);
        }
    }
}
