using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects;

namespace Sharp_Mapper.Units
{
    internal class UnitTestMap
    {
        public static void Run()
        {
            var employee = Employee.GetTestObject();

            var mapper = new Mapper<EmployeeDto, Employee>();
            var mapperResponse = mapper.Map(employee);

            if (mapperResponse.IsSuccess)
            {
                var employeeDto = mapperResponse.Value;
                if (employeeDto.Id == employee.Id &&
                    employeeDto.Firstname == employee.Firstname &&
                    employeeDto.Lastname == employee.Lastname)
                {
                    Console.WriteLine("Test 'Map' passed!");
                }
                else
                {
                    Console.WriteLine("Test 'Map' failed!");
                }
            }
            else
            {
                Console.WriteLine("Test 'Map' failed!");
            }
        }
    }
}
