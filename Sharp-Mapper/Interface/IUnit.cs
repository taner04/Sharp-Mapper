namespace Sharp_Mapper.Interface;

internal interface IUnit
{
    public string TestType { get; }
    public void Run();
}