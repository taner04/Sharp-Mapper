using Sharp_Mapper.Helper;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

public abstract class MapperController<TDestination, TSource>(bool ignoreAttributes, bool ignoreNullValues)
{
    #region Protected Properties

    // Cache destination properties by name for quick lookup
    protected static readonly Dictionary<string, PropertyInfo> DestinationProperties = typeof(TDestination)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    protected static readonly Dictionary<string, PropertyInfo> SourceProperties = typeof(TSource)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    // Cache source properties
    protected static readonly PropertyInfo[] DestinationPropertyInfos = typeof(TDestination).GetProperties();
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

    protected bool IgnoreNullValues { get; set; } = ignoreNullValues;
    protected bool IgnoreAttributes { get; set; } = ignoreAttributes;
    protected static readonly MapperHelper<TDestination, TSource> MapperHelper = new();

    #endregion
}