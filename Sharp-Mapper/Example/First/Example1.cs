using Sharp_Mapper.Mapper;

namespace Sharp_Mapper.Example.First;

public static class Example1
{
    public static void Run()
    {
        EmployeeDto employeeDto = new();

        // Create an instance of Employee
        var employee = new Employee
        {
            Id = null,
            Firstname = "John",
            Lastname = "Doe",
            Email = "johndoe@mail.de",
            Phone = "123456789"
        };

        // Create the mapper instance with attributes enabled
        var mapper = new MapperT<EmployeeDto, Employee>(false, false);
        var mapperResponse = mapper.Map(employee);

        // Handle mapper response
        if (mapperResponse.IsSuccess)
        {
            employeeDto = mapperResponse.Value;
            Console.WriteLine("Mapping successful! Employee -> EmployeeDto");
            Console.WriteLine($"Id: {employeeDto.Id}");
            Console.WriteLine($"Firstname: {employeeDto.Firstname}");
            Console.WriteLine($"Lastname: {employeeDto.Lastname}");
            //Console.WriteLine($"Fullname: {employeeDto.Fullname}");
        }
        else
        {
            // Print detailed error information
            Console.WriteLine("Mapping failed!");
            Console.WriteLine($"Error Type: {mapperResponse?.Error?.Type}");
            Console.WriteLine($"Error Description: {mapperResponse?.Error?.Description}");
        }

        Console.WriteLine();

        var employeeDto2 = new EmployeeDto
        {
            Id = 2,
            Firstname = "Jane",
            Lastname = "Doe"
        };

        var mapperResponseBack = mapper.MapBack(employeeDto2);
        if (mapperResponseBack.IsSuccess)
        {
            var emp = mapperResponseBack.Value;
            Console.WriteLine("Mapping successful! Employee -> EmployeeDto");
            Console.WriteLine($"Id: {emp.Id}");
            Console.WriteLine($"Firstname: {emp.Firstname}");
            Console.WriteLine($"Lastname: {emp.Lastname}");
            Console.WriteLine($"Email: {emp.Email}");
            Console.WriteLine($"Email: {emp.Phone}");
        }
        else
        {
            // Print detailed error information
            Console.WriteLine("Mapping failed!");
            Console.WriteLine($"Error Type: {mapperResponseBack?.Error?.Type}");
            Console.WriteLine($"Error Description: {mapperResponseBack?.Error?.Description}");
        }
    }
}