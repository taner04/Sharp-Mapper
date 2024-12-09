namespace Sharp_Mapper.Interface.Unit;

internal interface IUnit
{
    public string TestType { get; }
    public void Run();
}