using Sharp_Mapper.First;
using Sharp_Mapper.Mapper;

namespace Sharp_Mapper.Example;

public static class Example1
{
    public static void Run()
    {
        // Create an instance of Employee
        var employee = new Employee
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            Email = "johndoe@mail.de",
            Phone = "123456789",
        };

        // Create the mapper instance with attributes enabled
        var mapper = new MapperT<EmployeeDto, Employee>(ignoreAttributes: false);
        var mapperResponse = mapper.Map(employee);

        // Handle mapper response
        if (mapperResponse.IsSuccess)
        {
            var employeeDto = mapperResponse.Value;
            Console.WriteLine("Mapping successful! Employee -> EmployeeDto");
            Console.WriteLine($"EmployeeDto: Id = {employeeDto.Id}, Firstname = {employeeDto.Firstname}, Lastname = {employeeDto.Lastname}");
        }
        else
        {
            // Print detailed error information
            Console.WriteLine("Mapping failed!");
            Console.WriteLine($"Error Header: {mapperResponse.Error.Header}");
            Console.WriteLine($"Error Description: {mapperResponse.Error.Description}");
        }
    }
}