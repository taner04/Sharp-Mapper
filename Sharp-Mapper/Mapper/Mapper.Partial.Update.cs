using Sharp_Mapper.Helper;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

/// <summary>
/// Partial class of 'Mapper' for updating properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
public sealed partial class Mapper<TDestination, TSource>
{
    /// <summary>
    /// Updates the properties of the destination object with the values from the source object.
    /// </summary>
    /// <typeparam name="TType">The type of the destination object.</typeparam>
    /// <param name="source">The source object containing the new values.</param>
    /// <param name="destination">The destination object to be updated.</param>
    public void Update<TType>(object source, ref TType destination)
    {
        switch (destination)
        {
            case TDestination:
                {
                    UpdateProperties(source, ref destination, SourceProperties, DestinationPropertyInfos);
                    break;
                }
            case TSource:
                {
                    UpdateProperties(source, ref destination, DestinationProperties, SourcePropertiesInfo);
                    break;
                }
        }
    }

    /// <summary>
    /// Updates the properties of the destination object with the values from the source object.
    /// </summary>
    /// <typeparam name="T">The type of the destination object.</typeparam>
    /// <param name="source">The source object containing the new values.</param>
    /// <param name="destinationObject">The destination object to be updated.</param>
    /// <param name="sourceProperties">A dictionary of source property names and their corresponding PropertyInfo objects.</param>
    /// <param name="destinationProperties">An array of PropertyInfo objects representing the properties of the destination object.</param>
    /// <exception cref="Exception">Thrown when there is an error setting a property value.</exception>
    private void UpdateProperties<T>(object source, ref T destinationObject, Dictionary<string, PropertyInfo> sourceProperties, PropertyInfo[] destinationProperties)
    {
        foreach (var destinationProperty in destinationProperties)
        {
            if (!sourceProperties.TryGetValue(destinationProperty.Name, out var sourceProp))
                continue;

            var sourceValue = source?.GetType().GetProperty(sourceProp.Name)?.GetValue(source);
            if (sourceValue == null)
                continue;

            var error = SetPropertyValue(destinationProperty, sourceValue, destinationObject, IgnoreNullValues);
            if (error.ErrorType != ErrorType.Success)
            {
                throw new Exception(ErrorHelper.GetDescription(sourceProp, destinationProperty, error.ErrorType), error.Exception);
            }
        }
    }
}
