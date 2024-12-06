using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper.Validation_Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperRequieredProperty : Attribute, IValidation
    {
        public ErrorType ErrorType { get; set; }

        public bool IsValid(object? source) => source != null;
    }
}
