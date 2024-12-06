using Sharp_Mapper.Result;

namespace Sharp_Mapper.Interface;

public interface IValidation
{
    public ErrorType ErrorType { get; set; }
    bool IsValid(object? source);
}