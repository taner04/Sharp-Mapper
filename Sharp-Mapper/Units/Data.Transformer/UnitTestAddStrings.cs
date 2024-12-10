using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test.Objects.String;
using Sharp_Mapper.Units.Test_Objects.String;

namespace Sharp_Mapper.Units.Data.Transformer;

internal class UnitTestAddStrings : IUnit
{
    public string TestType { get; } = "Transform string";

    public void Run()
    {
        var combiner = StringModel.GetTestObject("John", "Doe");

        var mapper = new Mapper<StringModelDto, StringModel>();
        var mapperResponse = mapper.Map(combiner);

        if (mapperResponse.IsSuccess)
        {
            var combinerDto = mapperResponse.Value;
            var splitDtoName = combinerDto.Result.Split(" ");
            
            if (splitDtoName[0] == combiner.Value1 && splitDtoName[1] == combiner.Value2) UnitHelper.PrintSuccess(TestType);
            else UnitHelper.PrintFail(TestType);
        }
        else
        {
            UnitHelper.PrintError(mapperResponse);
            UnitHelper.PrintFail(TestType);
        }
    }
}