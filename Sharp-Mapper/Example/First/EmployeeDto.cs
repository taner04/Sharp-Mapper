using Sharp_Mapper.Mapper.Validation_Attributes;

namespace Sharp_Mapper.Example.First;

public class EmployeeDto
{
    //[MapperCombineString("Firstname", "Lastname")]
    //public string Fullname { get; set; }
    [MapperRequieredProperty]
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}