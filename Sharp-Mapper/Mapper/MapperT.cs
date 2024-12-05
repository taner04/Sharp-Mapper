using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper
{
    /// <summary>
    /// Generic mapper for mapping properties between source <typeparamref name="TSource"/>
    /// and destination <typeparamref name="TDestination"/> objects.
    /// </summary>
    public class MapperT<TDestination, TSource>(bool ignoreAttributes = true, bool ignoreNullValue = false)
        : IMapper<TDestination, TSource>
    {
        private bool IgnoreNullValue { get; set; } = ignoreNullValue;
        private bool IgnoreAttributes { get; set; } = ignoreAttributes;

        private static readonly Dictionary<string, PropertyInfo> DestinationPropertiesDict =
            typeof(TDestination).GetProperties().ToDictionary(p => p.Name);
        private static readonly PropertyInfo[] SourceProperties = typeof(TSource).GetProperties();

        public void EnableIgnoreNullValue() => IgnoreNullValue = true;
        public void DisableIgnoreNullValue() => IgnoreNullValue = false;
        public void EnableIgnoreAttributes() => IgnoreAttributes = true;
        public void DisableIgnoreAttributes() => IgnoreAttributes = false;

        /// <summary>
        /// Maps properties from source to destination object.
        /// </summary>
        /// <param name="source">Source object with properties to map.</param>
        /// <returns>A ResultT object with the destination object if successful.</returns>
        public ResultT<TDestination> Map(TSource source)
        {
            var destination = Activator.CreateInstance<TDestination>();
            foreach (var sourceProp in SourceProperties)
            {
                if (!DestinationPropertiesDict.TryGetValue(sourceProp.Name, out var destinProp)) continue;
                var result = IgnoreAttributes
                    ? MapWithoutAttributeValidation(sourceProp, destinProp, source, destination)
                    : MapWithAttributeValidation(sourceProp, destinProp, source, destination);
                if (!result.IsSuccess)
                {
                    return result;
                }
            }
            return ResultT<TDestination>.Success(destination);
        }

        /// <summary>
        /// Maps properties without attribute checks.
        /// </summary>
        /// <param name="sourceProp">Property info of the source object.</param>
        /// <param name="destinProp">Property info of the destination object.</param>
        /// <param name="source">Source object for the mapping.</param>
        /// <param name="destination">Destination object to map properties to.</param>
        private static ResultT<TDestination> MapWithoutAttributeValidation(PropertyInfo sourceProp,
            PropertyInfo destinProp, TSource source, TDestination destination)
        {
            SetDestinationPropertyValue(sourceProp, destinProp, destination, source);
            return ResultT<TDestination>.Success(destination);
        }

        /// <summary>
        /// Maps properties with attribute checks.
        /// </summary>
        /// <param name="sourceProp">Property info of the source object.</param>
        /// <param name="destinProp">Property info of the destination object.</param>
        /// <param name="source">Source object for the mapping.</param>
        /// <param name="destination">Destination object to map properties to.</param>
        private static ResultT<TDestination> MapWithAttributeValidation(PropertyInfo sourceProp,
            PropertyInfo destinProp, TSource source, TDestination destination)
        {
            var error = MapperExtension<TSource>.CheckAttributes(sourceProp, destinProp, source);
            if (error != ErrorType.Success)
            {
                return ResultT<TDestination>.Failure(Error.Create("Mapping Error", error));
            }
            SetDestinationPropertyValue(sourceProp, destinProp, destination, source);
            return ResultT<TDestination>.Success(destination);
        }

        /// <summary>
        /// Sets property value on destination object.
        /// </summary>
        /// <param name="sourceProp">Source property information.</param>
        /// <param name="destinProp">Destination property information.</param>
        /// <param name="destination">Destination object for property values.</param>
        /// <param name="source">Source object containing the property values.</param>
        private static void SetDestinationPropertyValue(PropertyInfo sourceProp, PropertyInfo destinProp,
            TDestination destination, TSource source)
        {
            var value = sourceProp.GetValue(source);
            if (value != null && destinProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
            {
                value = MapperExtension<TSource>.SetProperty(value);
            }
            else if (value == null && destinProp.PropertyType.IsValueType &&
                     Nullable.GetUnderlyingType(destinProp.PropertyType) == null)
            {
                throw new InvalidOperationException(
                    $"Cannot assign null to non-nullable property '{destinProp.Name}'.");
            }
            destinProp.SetValue(destination, value);
        }
    }
}