using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects.Numeric.Double;
using Sharp_Mapper.Units.Test_Objects.Numeric.Int;
using Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Double;

namespace Sharp_Mapper.Units.Combiner;

internal class UnitTestCombinerNumber : IUnit
{
    public string TestType { get; } = "CombinerNumeric";

    public void Run()
    {
        Console.Write("Value type Int: ");
        IntTest();
        Console.Write("Value type Double: ");
        DoubleTest();
    }

    private void IntTest()
    {
        var combiner = IntModel.GetTestObject(5, 5);

        var mapper = new Mapper<IntModelCombineDto, IntModel>();
        var mapperResponse = mapper.Map(combiner);

        if (mapperResponse.IsSuccess)
        {
            var combinerDto = mapperResponse.Value;
            if (combinerDto.Result == combiner.FirstNumber + combiner.SecondNumber)
                UnitHelper.PrintSuccess(TestType);
            else
                UnitHelper.PrintFail(TestType);
        }
        else
        {
            UnitHelper.PrintError(mapperResponse);
            UnitHelper.PrintFail(TestType);
        }
    }

    private void DoubleTest()
    {
        var combiner = DoubleModel.GetTestObject(5.5, 4.5);

        var mapper = new Mapper<DoubleModelCombineDto, DoubleModel>();
        var mapperResponse = mapper.Map(combiner);

        if (mapperResponse.IsSuccess)
        {
            var combinerDto = mapperResponse.Value;
            if (combinerDto.Result == combiner.FirstNumber + combiner.SecondNumber)
                UnitHelper.PrintSuccess(TestType);
            else
                UnitHelper.PrintFail(TestType);
        }
        else
        {
            UnitHelper.PrintError(mapperResponse);
            UnitHelper.PrintFail(TestType);
        }
    }
}