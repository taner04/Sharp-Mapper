using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

/// <summary>
/// Provides functionality to map properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
/// <param name="ignoreAttributes">Indicates whether to ignore attributes during mapping.</param>
/// <param name="ignoreNullValues">Indicates whether to fill null values during mapping.</param>
public class MapperT<TDestination, TSource>(bool ignoreAttributes = true, bool ignoreNullValues = true)
    : IMapper<TDestination, TSource>
{
    private static readonly MapperExtension<TDestination, TSource> MapperExtension = new();

    // Cache destination properties by name for quick lookup
    private static readonly Dictionary<string, PropertyInfo> DestinationProperties = typeof(TDestination)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    private static readonly Dictionary<string, PropertyInfo> SourceProperties = typeof(TSource)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    // Cache source properties
    private static readonly PropertyInfo[] DestinationPropertyInfos = typeof(TDestination).GetProperties();
    private static readonly PropertyInfo[] SourcePropertiesInfo = typeof(TSource).GetProperties();

    private bool IgnoreNullValues { get; set; } = ignoreNullValues;
    private bool IgnoreAttributes { get; set; } = ignoreAttributes;

    /// <summary>
    /// Maps properties from the source object to a new instance of the destination object.
    /// </summary>
    /// <param name="mapperObject">The source object.</param>
    /// <returns>A result containing the mapped destination object or an error.</returns>
    public ResultT<TDestination> Map(TSource mappableObject)
    {
        var destionationObject = Activator.CreateInstance<TDestination>();

        foreach (var destProp in DestinationPropertyInfos)
        {
            SourceProperties.TryGetValue(destProp.Name, out var sourceProp);
            var sourceValue = sourceProp.GetValue(mappableObject);
            var propertyAtr = destProp.GetCustomAttributes().ToList();

            var containsCombineAtr = MapperExtension.ContainsCombineAttribute(propertyAtr, out var combiner);

            if (!containsCombineAtr)
            {
                var containsValidationAtr= MapperExtension.ContainsValidationAttribute(propertyAtr, out var validator);
                if (!containsValidationAtr)
                {
                    var error = SetPropertyValue(destProp, sourceValue, destionationObject);
                    if (error != ErrorType.Success)
                        return ResultT<TDestination>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProp, destProp, error), error));
                }
                else
                {
                    if (validator.IsValid(sourceValue))
                    {
                        var error = SetPropertyValue(destProp, sourceValue, destionationObject);
                        if (error != ErrorType.Success)
                            return ResultT<TDestination>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProp, destProp, error), error));

                    }
                    else
                    {
                        return ResultT<TDestination>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProp, destProp, validator.ErrorType), validator.ErrorType));
                    }
                }
            }
            else
            {
                combiner.Combine(sourceValue);
            }
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
                    return ResultT<TSource>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProp, sourceProp, error), error));
                }
            }
        }
        return ResultT<TSource>.Success(destionationObject);
    }

    /// <summary>
    /// Enables ignoring attributes during mapping.
    /// </summary>
    public void EnableIgnoreAttributes()
    {
        IgnoreAttributes = true;
    }

    /// <summary>
    /// Disables ignoring attributes during mapping.
    /// </summary>
    public void DisableIgnoreAttributes()
    {
        IgnoreAttributes = false;
    }

    /// <summary>
    /// Enables filling null values during mapping.
    /// </summary>
    public void EnableFillNullValues()
    {
        IgnoreNullValues = true;
    }

    /// <summary>
    /// Disables filling null values during mapping.
    /// </summary>
    public void DisableFillNullValues()
    {
        IgnoreNullValues = false;
    }

    private ErrorType SetPropertyValue<T>(PropertyInfo property, object? sourceValue, T destinationObject)
    {
        try
        {
            if (!IgnoreNullValues && sourceValue == null)
            {
                return ErrorType.NullProperty;
            }
            property.SetValue(destinationObject, sourceValue);
            return ErrorType.Success;
        }
        catch (Exception)
        {
            return ErrorType.Unknown;
        }
    }
}
