# Sharp-Mapper

Sharp-Mapper is a C# library designed to facilitate the mapping, mapback, and updating of entities. It simplifies the transformation of data between different layers of an application.

> **Note:**  
> This is my first larger project and is still in development. Features may be incomplete, and improvements are ongoing. If you have any suggestions, improvements, or tips, please contact me!

## Features

- **Mapping**: Convert objects from one type to another.
- **MapBack**: Reverse mapping from the target object back to the source object.
- **Update Entities**: Update existing entities with new data.
- **Response logic**: Includes error information when errors occur, or the mapped object when the mapping is successful.

## Use cases

Sharp-Mapper is versatile and can be applied in various scenarios, including:

- Data Transfer Objects (DTOs): Map database entities to DTOs for seamless data transfer across layers (e.g., service to presentation layers).
- API Models: Convert API request models to domain models and vice versa.
- View Models: Map domain models to view models in MVC or MVVM architectures.
- Configuration Mapping: Transform external configuration settings (e.g., JSON, XML) into strongly-typed configuration classes.
- Data Import/Export: Facilitate mapping during data import/export between formats.
- Testing: Create mock objects for unit testing by mapping real objects to test-friendly formats.

## Examples

### Example 1: Mapping from Source to Target

To map from the target back to the source, simply call the `MapBack(target)` method. It works similarly to the `Map(source)` method. The mapper also provides a `Dispose()` to call via `using` or `mapper.Dispose()`.

```csharp
// Define test data
var employeeDummy = Employee.GetTestObject();

// Create a mapper instance
var mapper = new Mapper<EmployeeDto, Employee>();

// Perform mapping from source to target
var resultSourceToTarget = mapper.Map(employeeDummy);

// Access the mapped object
var employeeDto = resultSourceToTarget.Value;

// Example output
Console.WriteLine($"Mapped Employee DTO: {employeeDto.Name}");
```

### Example 2: Update 
To update from the target back to the source, simply call the same method. The first parameter is the source object, and the second is the target object which gets updated using the `ref` keyword.

```csharp
// Define test data
var employee = Employee.GetTestObject();
var employeeDto = EmployeeDto.GetTestObject();

// Create a mapper instance
var mapper = new Mapper<EmployeeDto, Employee>();

// Update the source object with data from the target object
mapper.Update(employeeDto, ref employee);
```
