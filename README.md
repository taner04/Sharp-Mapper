# Sharp-Mapper

Sharp-Mapper is a C# library designed to facilitate the mapping, mapback, and updating of entities. It aims to simplify the process of transforming data between different layers of an application.

## Features

- **Mapping**: Convert objects from one type to another.
- **Mapback**: Reverse mapping from the target object back to the source object.
- **Update Entities**: Update existing entities with new data.

## Use cases

- Data Transfer Objects (DTOs): Map database entities to DTOs for data transfer across different layers of the application, such as from the service layer to the presentation layer.
- API Models: Convert API request models to domain models and vice versa.
- View Models: Map domain models to view models used in MVC or MVVM architectures.
- Configuration Mapping: Map configuration settings from external files (e.g., JSON, XML) to strongly typed configuration classes.
- Data Import/Export: Facilitate the mapping of data between different formats during import and export operations.
- Testing: Use mapping to create mock objects for unit testing by converting real objects to test-friendly formats.
