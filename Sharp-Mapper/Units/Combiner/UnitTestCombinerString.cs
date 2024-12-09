using Sharp_Mapper.Interface.Unit;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects.Combiner.String;

namespace Sharp_Mapper.Units.Combiner
{
    internal class UnitTestCombinerString : IUnit
    {
        public string TestType { get; } = "CombinerString";
        public void Run()
        {
            var combiner = StringCombiner.GetTestObject();

            var mapper = new Mapper<StringCombinerDto, StringCombiner>();
            var mapperResponse = mapper.Map(combiner);

            if (mapperResponse.IsSuccess)
            {
                var combinerDto = mapperResponse.Value;
                var splitDtoName = combinerDto.Fullname.Split(" ");
                if (splitDtoName[0] == combiner.Firstname && splitDtoName[1] == combiner.Lastname)
                {
                    UnitHelper.PrintSuccess(TestType);
                }
                else
                {
                    UnitHelper.PrintFail(TestType);
                }
            }
            else
            {
                UnitHelper.PrintError(mapperResponse);
                UnitHelper.PrintFail(TestType);
            }
        }
    }
}
