using Sharp_Mapper.Result;

namespace Sharp_Mapper.Interface;

/// <summary>
///     Defines a contract for mapping between two types.
/// </summary>
/// <typeparam name="TDestination">The type to map to.</typeparam>
/// <typeparam name="TSource">The type to map from.</typeparam>
public interface IMapper<TDestination, TSource>
{
    /// <summary>
    ///     Maps an instance of <typeparamref name="TSource" /> to <typeparamref name="TDestination" />.
    /// </summary>
    /// <param name="source">The source instance to map from.</param>
    /// <returns>A <see cref="ResultT{TDestination}" /> containing the mapped instance or an error.</returns>
    ResultT<TDestination> Map(TSource source);

    /// <summary>
    ///     Maps an instance of <typeparamref name="TDestination" /> back to <typeparamref name="TSource" />.
    /// </summary>
    /// <param name="destination">The destination instance to map from.</param>
    /// <returns>A <see cref="ResultT{TSource}" /> containing the mapped instance or an error.</returns>
    ResultT<TSource> MapBack(TDestination destination);

    /// <summary>
    ///     Updates an instance of <typeparamref name="TSource" /> with values from <typeparamref name="TDestination" />.
    /// </summary>
    /// <param name="source">The source instance to update.</param>
    /// <param name="destination">The destination instance to update from.</param>
    /// <returns>A <see cref="ResultT{TSource}" /> containing the updated instance or an error.</returns>
    public void Update<TType>(object source, ref TType destination);
}