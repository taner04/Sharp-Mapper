using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper
{
    public class MapperT<TDestination, TSource>(bool ignoreAttributes = true, bool fillNullValues = true) : IMapper<TDestination, TSource>
    {
        private bool FillNullValues { get; set; } = fillNullValues;
        private bool IgnoreAttributes { get; set; } = ignoreAttributes;

        // Cache destination properties by name for quick lookup
        private static readonly Dictionary<string, PropertyInfo> _destinationProperties = typeof(TDestination)
            .GetProperties()
            .ToDictionary(p => p.Name, p => p);

        // Cache source properties
        private static readonly PropertyInfo[] _sourceProperties = typeof(TSource).GetProperties();

        public void EnableIgnoreAttributes() => IgnoreAttributes = true;

        public void DisableIgnoreAttributes() => IgnoreAttributes = false;

        public ResultT<TDestination> Map(TSource source)
        {
            var destination = Activator.CreateInstance<TDestination>();

            foreach (var sourceProp in _sourceProperties)
            {
                if (_destinationProperties.TryGetValue(sourceProp.Name, out var destinProp))
                {
                    var error = SetDestinationPropertyValue(sourceProp, destinProp, destination, source);
                    if (error != ErrorType.Success)
                    {
                        return ResultT<TDestination>.Failure(
                            Error.Create($"Failed to map {sourceProp.Name}", error)
                        );
                    }
                }
            }

            return ResultT<TDestination>.Success(destination);
        }

        private ErrorType SetDestinationPropertyValue(PropertyInfo sourceProp, PropertyInfo destinProp, TDestination destination, TSource source)
        {
            // Check for type compatibility
            if (!destinProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                return ErrorType.TypeMismatch;

            var sourceValue = sourceProp.GetValue(source);

            // Handle null values if FillNullValues is true
            if (!FillNullValues && sourceValue == null)
                return ErrorType.NullProperty;

            // Check for attributes if IgnoreAttributes is false
            if (!IgnoreAttributes)
            {
                var error = MapperExtension<TSource>.CheckAttributes(sourceProp, destinProp, source);
                if (error != ErrorType.Success)
                    return error;
            }

            // Set the property value
            destinProp.SetValue(destination, MapperExtension<TSource>.SetProperty(sourceValue));
            return ErrorType.Success;
        }
    }
}
