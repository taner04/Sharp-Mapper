using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects;

namespace Sharp_Mapper.Units
{
    internal class UnitTestMapBack
    {
        public static void Run()
        {
            var employeeDto = EmployeeDto.GetTestObject();

            var mapper = new Mapper<EmployeeDto, Employee>();
            var mapperResponse = mapper.MapBack(employeeDto);

            if (mapperResponse.IsSuccess)
            {
                var employee = mapperResponse.Value;
                if (employeeDto.Id == employee.Id &&
                    employeeDto.Firstname == employee.Firstname &&
                    employeeDto.Lastname == employee.Lastname)
                {
                    Console.WriteLine("Test 'MapBack' passed!");
                }
                else
                {
                    Console.WriteLine("Test 'MapBack' failed!");
                }
            }
            else
            {
                Console.WriteLine("Test 'MapBack' failed!");
            }
        }
    }
}
