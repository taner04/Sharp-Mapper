namespace Sharp_Mapper.Interface.Unit;

internal interface INumericUnit<TType>
{
    public TType FirstNumber { get; set; }
    public TType SecondNumber { get; set; }
}