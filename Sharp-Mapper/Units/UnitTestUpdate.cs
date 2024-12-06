using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects;

namespace Sharp_Mapper.Units
{
    internal class UnitTestUpdate
    {
        public static void Run()
        {
            // Arrange
            var employee = Employee.GetTestObject();

            var employeeDto = new EmployeeDto
            {
                Id = 2,
                Firstname = "Jane",
                Lastname = "Doe"
            };

            var mapper = new Mapper<EmployeeDto, Employee>();

            // Act
            mapper.Update(employeeDto, ref employee);

            // Assert
            if (employee != null &&
                employee.Id == employeeDto.Id &&
                employee.Firstname == employeeDto.Firstname &&
                employee.Lastname == employeeDto.Lastname &&
                employee.Email == employee.Email && // Email should remain unchanged
                employee.Phone == employee.Phone)   // Phone should remain unchanged
            {
                Console.WriteLine("Test 'Update' passed!");
            }
            else
            {
                Console.WriteLine("Test 'Update' failed!");
            }
        }
    }
}
