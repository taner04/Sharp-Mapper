using Sharp_Mapper.Helper;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

/// <summary>
///     Abstract base class for mapping properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
public abstract class MapperController<TDestination, TSource>(bool ignoreAttributes, bool ignoreNullValues)
{
    #region Protected Properties

    /// <summary>
    ///     Cache destination properties by name for quick lookup.
    /// </summary>
    protected static readonly Dictionary<string, PropertyInfo> DestinationProperties = typeof(TDestination)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    /// <summary>
    ///     Cache source properties by name for quick lookup.
    /// </summary>
    protected static readonly Dictionary<string, PropertyInfo> SourceProperties = typeof(TSource)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    /// <summary>
    ///     Cache destination properties.
    /// </summary>
    protected static readonly PropertyInfo[] DestinationPropertyInfos = typeof(TDestination).GetProperties();

    /// <summary>
    ///     Cache source properties.
    /// </summary>
    protected static readonly PropertyInfo[] SourcePropertiesInfo = typeof(TSource).GetProperties();

    #endregion

    #region Methods

    /// <summary>
    ///     Enables ignoring attributes during mapping.
    /// </summary>
    public void EnableIgnoreAttributes()
    {
        IgnoreAttributes = true;
    }

    /// <summary>
    ///     Disables ignoring attributes during mapping.
    /// </summary>
    public void DisableIgnoreAttributes()
    {
        IgnoreAttributes = false;
    }

    /// <summary>
    ///     Enables filling null values during mapping.
    /// </summary>
    public void EnableFillNullValues()
    {
        IgnoreNullValues = true;
    }

    /// <summary>
    ///     Disables filling null values during mapping.
    /// </summary>
    public void DisableFillNullValues()
    {
        IgnoreNullValues = false;
    }

    #endregion

    #region Pub Properties

    /// <summary>
    ///     Gets or sets a value indicating whether to ignore null values during mapping.
    /// </summary>
    protected bool IgnoreNullValues { get; set; } = ignoreNullValues;

    /// <summary>
    ///     Gets or sets a value indicating whether to ignore attributes during mapping.
    /// </summary>
    protected bool IgnoreAttributes { get; set; } = ignoreAttributes;

    /// <summary>
    ///     Helper for mapping properties between source and destination objects.
    /// </summary>
    protected static readonly MapperHelper<TDestination, TSource> MapperHelper = new();

    #endregion
}
