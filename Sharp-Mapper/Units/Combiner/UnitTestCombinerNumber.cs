using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects.Combiner.Numeric_Combiner;

namespace Sharp_Mapper.Units.Combiner
{
    internal class UnitTestCombinerNumber : IUnit
    {
        public string TestType { get; } = "CombinerNumeric";
        public void Run()
        {
            var combiner = NumericCombiner.GetTestObject();

            var mapper = new Mapper<NumericCombinerDto, NumericCombiner>();
            var mapperResponse = mapper.Map(combiner);

            if (mapperResponse.IsSuccess)
            {
                var combinerDto = mapperResponse.Value;
                if (combinerDto.Result == (combiner.FirstNumber + combiner.SecondNumber))
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
