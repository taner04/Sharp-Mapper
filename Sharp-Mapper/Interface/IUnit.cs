namespace Sharp_Mapper.Interface;

/// <summary>
/// Defines the interface for a unit that can be tested and run.
/// </summary>
internal interface IUnit
{
    /// <summary>
    /// Gets the type of the test.
    /// </summary>
    string TestType { get; }

    /// <summary>
    /// Runs the unit.
    /// </summary>
    void Run();
}
