using System.Reflection;
using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

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
    /// <param name="mappableObject">The source object.</param>
    /// <returns>A result containing the mapped destination object or an error.</returns>
    public ResultT<TDestination> Map(TSource mappableObject)
    {
        var destionationObject = Activator.CreateInstance<TDestination>();

        foreach (var destProp in DestinationPropertyInfos)
        {
            SourceProperties.TryGetValue(destProp.Name, out var sourceProp);

            var propertyAtr = destProp.GetCustomAttributes().ToList();
            var containsCombineAtr = MapperExtension.ContainsCombineAttribute(propertyAtr, out var combiner);
            var containsSubtractAtr = MapperExtension.ContainsSubtractAttribute(propertyAtr, out var subtract);

            ErrorType error;
            if (!containsCombineAtr && !containsSubtractAtr)
            {
                var sourceValue = sourceProp.GetValue(mappableObject);
                var containsValidationAtr =
                    MapperExtension.ContainsValidationAttribute(propertyAtr, out var validator) &&
                    IgnoreAttributes == false;
                if (!containsValidationAtr)
                {
                    error = SetPropertyValue(destProp, sourceValue, destionationObject);
                    if (error != ErrorType.Success)
                        return ResultT<TDestination>.Failure(
                            Error.Create(ErrorExtension.GetDescription(sourceProp, destProp, error), error));
                }
                else
                {
                    if (validator.IsValid(sourceValue))
                    {
                        error = SetPropertyValue(destProp, sourceValue, destionationObject);
                        if (error != ErrorType.Success)
                            return ResultT<TDestination>.Failure(
                                Error.Create(ErrorExtension.GetDescription(sourceProp, destProp, error), error));
                    }
                    else
                    {
                        return ResultT<TDestination>.Failure(Error.Create(
                            ErrorExtension.GetDescription(sourceProp, destProp, validator.ErrorType),
                            validator.ErrorType));
                    }
                }
            }
            else
            {
                var value = containsCombineAtr
                    ? combiner.Combine(
                        MapperExtension.GetValuesForCombinerAtr(SourcePropertiesInfo, combiner, mappableObject))
                    : subtract.Combine(
                        MapperExtension.GetValuesForSubtractAtr(SourcePropertiesInfo, subtract, mappableObject));

                error = SetPropertyValue(destProp, value, destionationObject);
                if (error != ErrorType.Success)
                    return ResultT<TDestination>.Failure(
                        Error.Create(ErrorExtension.GetDescription(sourceProp, destProp, error), error));
            }
        }

        return ResultT<TDestination>.Success(destionationObject);
    }

    public ResultT<TSource> MapBack(TDestination mappableObject)
    {
        var destionationObject = Activator.CreateInstance<TSource>();

        foreach (var sourceProp in SourcePropertiesInfo)
            if (DestinationProperties.TryGetValue(sourceProp.Name, out var destProp))
            {
                var error = SetPropertyValue(sourceProp, destProp.GetValue(mappableObject), destionationObject);
                if (error != ErrorType.Success)
                    return ResultT<TSource>.Failure(
                        Error.Create(ErrorExtension.GetDescription(sourceProp, sourceProp, error), error));
            }

        return ResultT<TSource>.Success(destionationObject);
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