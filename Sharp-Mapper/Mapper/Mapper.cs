using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

/// <summary>
///     Provides functionality to map properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
/// <param name="ignoreAttributes">Indicates whether to ignore attributes during mapping.</param>
/// <param name="ignoreNullValues">Indicates whether to fill null values during mapping.</param>
public sealed partial class Mapper<TDestination, TSource>(bool ignoreAttributes = true, bool ignoreNullValues = true)
    : MapperController<TDestination, TSource>(ignoreAttributes, ignoreNullValues), IMapper<TDestination, TSource>
{
    /// <summary>
    ///     Maps properties from the source object to a new instance of the destination object.
    /// </summary>
    /// <param name="sourceObject">The source object.</param>
    /// <returns>A result containing the mapped destination object or an error.</returns>
    public ResultT<TDestination> Map(TSource sourceObject)
    {
        var destionationObject = Activator.CreateInstance<TDestination>();

        foreach (var destinationProperty in DestinationPropertyInfos)
        {
            SourceProperties.TryGetValue(destinationProperty.Name, out var sourceProperty);
            var value = sourceProperty?.GetValue(sourceObject);
            
            var propertyAtr = destinationProperty.GetCustomAttributes().ToList();

            if(MapperHelper.ContainsCombineAttribute(propertyAtr, out var dateTransformer))
            {
                var combinerResponse = dateTransformer.Combine(SourcePropertiesInfo, sourceObject, out var combinerValue);
                if (combinerResponse != ErrorType.Success)
                { 
                    return ResultT<TDestination>.Failure(MapperHelper.CreateError(sourceProperty, destinationProperty, combinerResponse));
                }
                value = combinerValue;
            }

            if(MapperHelper.ContainsValidationAttribute(propertyAtr, out var validator) && !validator.IsValid(value))
            {
                return ResultT<TDestination>.Failure(MapperHelper.CreateError(sourceProperty, destinationProperty, ErrorType.RequieredProperty));
            }

            var setValueResponse = MapperHelper.TrySetValue(sourceProperty, destinationProperty, value, sourceObject, destionationObject, IgnoreNullValues);
            if (!setValueResponse.IsSuccess) return setValueResponse.Error!;
        }

        return ResultT<TDestination>.Success(destionationObject);
    }

    public ResultT<TSource> MapBack(TDestination sourceObject)
    {
        var destionationObject = Activator.CreateInstance<TSource>();

        foreach (var sourceProp in SourcePropertiesInfo)
        {
            if(DestinationProperties.TryGetValue(sourceProp.Name, out var destProp))
            {
                var value = destProp.GetValue(sourceObject);

                var setValueResponse = MapperHelper.TrySetValue(destProp, sourceProp, value, sourceObject, destionationObject,IgnoreNullValues);
                if (!setValueResponse.IsSuccess)
                    return setValueResponse.Error!;
            }
        }

        return ResultT<TSource>.Success(destionationObject);
    }
}