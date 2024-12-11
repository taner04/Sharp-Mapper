using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper.Attributes;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Helper;

/// <summary>
///     Provides extension methods for mapping properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
public class MapperHelper<TDestination, TSource>
{
    /// <summary>
    ///     Gets a dictionary of attributes and their corresponding error types.
    /// </summary>

    #region Attributes

    public bool ContainsCombineAttribute(List<Attribute>? attributes, out IDataTransformer dataTransformer)
    {
        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                var atrType = attribute.GetType();
                if (atrType != typeof(MapNumerics) && atrType != typeof(MapStrings)) continue;

                dataTransformer = (IDataTransformer)attribute;
                return true;
            }
        }

        dataTransformer = null!;
        return false;
    }

    public bool ContainsValidationAttribute(List<Attribute>? attributes, out IValidator validator)
    {
        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() != typeof(MapperRequieredProperty)) continue;

                validator = (IValidator)attribute;
                validator.ErrorType = ErrorType.RequieredProperty;
                return true;
            }
        }

        validator = null!;
        return false;
    }

    #endregion

    #region Error

    public Error CreateError(PropertyInfo? sourceProperty, PropertyInfo destinationProperty, ErrorType errorType)
    {
        var desc = ErrorExtension.GetDescription(sourceProperty, destinationProperty, errorType);
        return Error.Create(desc, errorType);
    }

    #endregion


    #region Set Property

    public ResultT<TType1> TrySetValue<TType1, TType2>(PropertyInfo? sourceProperty, PropertyInfo destinationProperty, object? value, TType1 sourceObject, TType2 destinationObject, bool ignoreNullValues)
    {
        var error = SetPropertyValue(destinationProperty, value, destinationObject, ignoreNullValues);

        return error != ErrorType.Success ?
            ResultT<TType1>.Failure(Error.Create(ErrorExtension.GetDescription(sourceProperty, destinationProperty, error), error)) :
            ResultT<TType1>.Success(sourceObject);
    }

    public ErrorType SetPropertyValue<T>(PropertyInfo property, object? sourceValue, T destinationObject, bool ignoreNullValues)
    {
        try
        {
            if (!ignoreNullValues)
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
    #endregion
}