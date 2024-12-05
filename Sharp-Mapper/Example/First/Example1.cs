using Sharp_Mapper.First;
using Sharp_Mapper.Mapper;

namespace Sharp_Mapper.Example;

public static class Example1
{
    public static void Run()
    {
        var employee = new Employee
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            Email = "johndoe@mail.de",
            Phone = "123456789",
        };

        var mapper = new MapperT<EmployeeDto, Employee>(ignoreAttributes: false);
        var mapperResponse = mapper.Map(employee);

        if (mapperResponse.IsSuccess)
        {
            var employeeDto = mapperResponse.Value;
            Console.WriteLine("Mapped, Employee -> EmployeeDto");
            Console.WriteLine($"EmployeeDto: {employeeDto.Id} {employeeDto.Firstname} {employeeDto.Lastname}");
        }
        else
        {
            Console.WriteLine("Header: {0}", mapperResponse.Error.Header);
            Console.WriteLine("Description: {0}",mapperResponse.Error.Description);
            Console.WriteLine("Details: {0}");
        }
    }
}