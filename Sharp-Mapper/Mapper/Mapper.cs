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
    private ErrorType _error;

    /// <summary>
    ///     Maps properties from the source object to a new instance of the destination object.
    /// </summary>
    /// <param name="mappableObject">The source object.</param>
    /// <returns>A result containing the mapped destination object or an error.</returns>
    public ResultT<TDestination> Map(TSource mappableObject)
    {
        var destionationObject = Activator.CreateInstance<TDestination>();

        foreach (var destinationProperty in DestinationPropertyInfos)
        {
            SourceProperties.TryGetValue(destinationProperty.Name, out var sourceProperty);

            var propertyAtr = destinationProperty.GetCustomAttributes().ToList();

            if(MapperHelper.ContainsCombineAttribute(propertyAtr, out var dateTransformer))
            {
                var combinerResponse = dateTransformer.Combine(SourcePropertiesInfo, mappableObject, out var combinerValue);
                if (combinerResponse != ErrorType.Success)
                {
                    return ResultT<TDestination>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProperty, destinationProperty, combinerResponse), combinerResponse));
                }

                var setValueCombinerResponse = TrySetValue(sourceProperty, destinationProperty, combinerValue, mappableObject, destionationObject);
                if (!setValueCombinerResponse.IsSuccess) return setValueCombinerResponse.Error!;

                continue;
            }

            var sourceValue = sourceProperty?.GetValue(mappableObject);

            if(MapperHelper.ContainsValidationAttribute(propertyAtr, out var validator) && !validator.IsValid(sourceValue))
            {
                return ResultT<TDestination>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProperty, destinationProperty, validator.ErrorType), validator.ErrorType));
            }

            var setValueResponse = TrySetValue(sourceProperty, destinationProperty, sourceValue, mappableObject, destionationObject);
            if (!setValueResponse.IsSuccess) return setValueResponse.Error!;
        }

        return ResultT<TDestination>.Success(destionationObject);
    }

    public ResultT<TSource> MapBack(TDestination mappableObject)
    {
        var destionationObject = Activator.CreateInstance<TSource>();

        foreach (var sourceProp in SourcePropertiesInfo)
        {
            if (DestinationProperties.TryGetValue(sourceProp.Name, out var destProp))
            {
                var error = SetPropertyValue(sourceProp, destProp.GetValue(mappableObject), destionationObject);
                if (error != ErrorType.Success)
                {
                    return ResultT<TSource>.Failure(
                        Error.Create(ErrorExtension.GetDescription(sourceProp, sourceProp, error), error));
                }
            }
        }

        return ResultT<TSource>.Success(destionationObject);
    }

    private ResultT<TDestination> TrySetValue(PropertyInfo? sourceProperty, PropertyInfo destinationProperty, object? value, TSource sourceObject, TDestination destinationObject)
    {
        _error = SetPropertyValue(destinationProperty, value, destinationObject);
        
        return _error != ErrorType.Success ? 
            ResultT<TDestination>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProperty, destinationProperty, _error), _error)) : 
            ResultT<TDestination>.Success(destinationObject);
    }

    private ErrorType SetPropertyValue<T>(PropertyInfo property, object? sourceValue, T destinationObject)
    {
        try
        {
            if (!IgnoreNullValues) return ErrorType.NullProperty;

            property.SetValue(destinationObject, sourceValue);
            return ErrorType.Success;
        }
        catch (Exception)
        {
            return ErrorType.Unknown;
        }
    }
}