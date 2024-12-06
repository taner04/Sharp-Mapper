using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects;

namespace Sharp_Mapper.Units
{
    internal class UnitTestMap : IUnit
    {
        public string TestType { get; } = "Map";

        public void Run()
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
                    UnitHelper.PrintSuccess(TestType);
                }
                else
                {
                    UnitHelper.PrintFail(TestType);
                }
            }
            else
            {
                UnitHelper.PrintError(mapperResponse);
                UnitHelper.PrintFail(TestType);
            }
        }
    }
}
