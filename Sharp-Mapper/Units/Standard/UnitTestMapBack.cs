using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects;

namespace Sharp_Mapper.Units.Standard
{
    internal class UnitTestMapBack : IUnit
    {
        public string TestType { get; } = "MapBack";

        public void Run()
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
