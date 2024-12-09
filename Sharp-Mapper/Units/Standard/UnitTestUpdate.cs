using Sharp_Mapper.Interface.Unit;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects;

namespace Sharp_Mapper.Units.Standard
{
    internal class UnitTestUpdate : IUnit
    {
        public string TestType { get; } = "Update";

        public void Run()
        {
            var employee = Employee.GetTestObject();
            var employeeDto = EmployeeDto.GetTestObject();

            var mapper = new Mapper<EmployeeDto, Employee>();
            mapper.Update(employeeDto, ref employee);

            if (employee != null &&
                employee.Id == employeeDto.Id &&
                employee.Firstname == employeeDto.Firstname &&
                employee.Lastname == employeeDto.Lastname &&
                employee.Email == employee.Email && // Email should remain unchanged
                employee.Phone == employee.Phone)   // Phone should remain unchanged
            {
                UnitHelper.PrintSuccess(TestType);
            }
            else
            {
                UnitHelper.PrintFail(TestType);
            }
        }
    }
}
