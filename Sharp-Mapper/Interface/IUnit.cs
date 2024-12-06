namespace Sharp_Mapper.Interface;

public interface IUnit
{
    public string TestType { get; }
    public void Run();
}