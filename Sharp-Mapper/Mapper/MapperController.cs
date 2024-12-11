using System.Reflection;

namespace Sharp_Mapper.Mapper;

/// <summary>
///     Abstract base class for mapping properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
public abstract class MapperController<TDestination, TSource>(bool ignoreAttributes, bool ignoreNullValues) : IDisposable
{
    #region Protected Properties

    /// <summary>
    ///     Cache destination properties by name for quick lookup.
    /// </summary>
    protected readonly Dictionary<string, PropertyInfo> DestinationProperties = typeof(TDestination)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    /// <summary>
    ///     Cache source properties by name for quick lookup.
    /// </summary>
    protected readonly Dictionary<string, PropertyInfo> SourceProperties = typeof(TSource)
        .GetProperties()
        .ToDictionary(p => p.Name, p => p);

    /// <summary>
    ///     Cache destination properties.
    /// </summary>
    protected PropertyInfo[] DestinationPropertyInfos = typeof(TDestination).GetProperties();

    /// <summary>
    ///     Cache source properties.
    /// </summary>
    protected PropertyInfo[] SourcePropertiesInfo = typeof(TSource).GetProperties();
    protected bool _isDisposed;

    #endregion

    #region Methods

    /// <summary>
    ///     Disposes the resources used by the MapperController.
    /// </summary>
    /// <param name="disposing">Indicates whether the method is called from Dispose method.</param>
    public virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                DestinationProperties.Clear();
                SourceProperties.Clear();
                DestinationPropertyInfos = null!;
                SourcePropertiesInfo = null!;
            }

            // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
            // TODO: Große Felder auf NULL setzen
            _isDisposed = true;
        }
    }

    // // TODO: Finalizer nur überschreiben, wenn "Dispose(bool disposing)" Code für die Freigabe nicht verwalteter Ressourcen enthält
    // ~MapperController()
    // {
    //     // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
    //     Dispose(disposing: false);
    // }

    /// <summary>
    ///     Disposes the resources used by the MapperController.
    /// </summary>
    public void Dispose()
    {
        // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

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

    #endregion
}
