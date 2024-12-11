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
    ///     Checks if the list of attributes contains a combine attribute and returns the corresponding data transformer.
    /// </summary>
    /// <param name="attributes">The list of attributes to check.</param>
    /// <param name="dataTransformer">The data transformer if a combine attribute is found.</param>
    /// <returns><c>true</c> if a combine attribute is found; otherwise, <c>false</c>.</returns>
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

    /// <summary>
    ///     Checks if the list of attributes contains a validation attribute and returns the corresponding validator.
    /// </summary>
    /// <param name="attributes">The list of attributes to check.</param>
    /// <param name="validator">The validator if a validation attribute is found.</param>
    /// <returns><c>true</c> if a validation attribute is found; otherwise, <c>false</c>.</returns>
    public bool ContainsValidationAttribute(List<Attribute>? attributes, out IValidator validator)
    {
        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() != typeof(MapperRequieredProperty))
                    continue;

                validator = (IValidator)attribute;
                validator.ErrorType = ErrorType.RequieredProperty;
                return true;
            }
        }

        validator = null!;
        return false;
    }

    /// <summary>
    ///     Creates an error object based on the provided source and destination properties and error type.
    /// </summary>
    /// <param name="sourceProperty">The source property that caused the error.</param>
    /// <param name="destinationProperty">The destination property that caused the error.</param>
    /// <param name="errorType">The type of the error.</param>
    /// <returns>An <see cref="Error"/> object representing the error.</returns>
    public Error CreateError(PropertyInfo? sourceProperty, PropertyInfo destinationProperty, ErrorType errorType)
    {
        var desc = ErrorHelper.GetDescription(sourceProperty, destinationProperty, errorType);
        return Error.Create(desc, errorType);
    }

    /// <summary>
    ///     Tries to set the value of a destination property and returns the result.
    /// </summary>
    /// <typeparam name="TType1">The type of the source object.</typeparam>
    /// <typeparam name="TType2">The type of the destination object.</typeparam>
    /// <param name="sourceProperty">The source property.</param>
    /// <param name="destinationProperty">The destination property.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="sourceObject">The source object.</param>
    /// <param name="destinationObject">The destination object.</param>
    /// <param name="ignoreNullValues">Whether to ignore null values.</param>
    /// <returns>A <see cref="ResultT{TType1}"/> representing the result of the operation.</returns>
    public ResultT<TType1> TrySetValue<TType1, TType2>(PropertyInfo? sourceProperty, PropertyInfo destinationProperty, object? value, TType1 sourceObject, TType2 destinationObject, bool ignoreNullValues)
    {
        var error = SetPropertyValue(destinationProperty, value, destinationObject, ignoreNullValues);

        return error != ErrorType.Success ?
            ResultT<TType1>.Failure(Error.Create(ErrorHelper.GetDescription(sourceProperty, destinationProperty, error), error)) :
            ResultT<TType1>.Success(sourceObject);
    }

    /// <summary>
    ///     Sets the value of a property on the destination object.
    /// </summary>
    /// <typeparam name="T">The type of the destination object.</typeparam>
    /// <param name="property">The property to set.</param>
    /// <param name="sourceValue">The value to set.</param>
    /// <param name="destinationObject">The destination object.</param>
    /// <param name="ignoreNullValues">Whether to ignore null values.</param>
    /// <returns>An <see cref="ErrorType"/> indicating the result of the operation.</returns>
    public ErrorType SetPropertyValue<T>(PropertyInfo property, object? sourceValue, T destinationObject, bool ignoreNullValues)
    {
        try
        {
            if (!ignoreNullValues) return ErrorType.NullProperty;

            property.SetValue(destinationObject, sourceValue);
            return ErrorType.Success;
        }
        catch (Exception)
        {
            return ErrorType.Unknown;
        }
    }
}
