using Mapper_Units.Test_Objects;
using Sharp_Mapper.Mapper;

namespace Mapper.Units.Mapper.Tests
{
    public class Map
    {
        #region Map back and forward
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

        [Fact]
        public void MapperMapBack_EmployeeDtoToEmployee_Sucess()
        {
            // Arrange
            var employeeDto = EmployeeDto.GetTestObject();
            var mapper = new Mapper<EmployeeDto,Employee>();
            // Act
            var mapperResponse = mapper.MapBack(employeeDto);
            // Assert
            Assert.Equal(employeeDto.Id, mapperResponse.Value.Id);
        }

        #endregion

        #region Update back and forward
        [Fact]
        public void MapperUpdate_EmployeeDto_Sucess()
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
        public void MapperUpdate_Employee_Sucess()
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
        #endregion
    }
}
