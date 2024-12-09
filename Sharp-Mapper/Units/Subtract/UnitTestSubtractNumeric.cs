using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects.Numeric.Int;
using Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Double;
using Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Int;

namespace Sharp_Mapper.Units.Subtract;

internal class UnitTestSubtractNumeric : IUnit
{
    public string TestType { get; } = "SubtractNumeric";

    public void Run()
    {
        Console.Write("Value type Int: ");
        IntTest();
        Console.Write("Value type Double: ");
        DoubleTest();
    }

    private void IntTest()
    {
        var combiner = IntModel.GetTestObject(10, 5);

        var mapper = new Mapper<IntModelSubtractDto, IntModel>();
        var mapperResponse = mapper.Map(combiner);

        if (mapperResponse.IsSuccess)
        {
            var combinerDto = mapperResponse.Value;
            if (combinerDto.Result == combiner.FirstNumber - combiner.SecondNumber)
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
        var combiner = DoubleModel.GetTestObject(10.5, 5.5);

        var mapper = new Mapper<DoubeModelSubtractDto, DoubleModel>();
        var mapperResponse = mapper.Map(combiner);

        if (mapperResponse.IsSuccess)
        {
            var combinerDto = mapperResponse.Value;
            if (combinerDto.Result == combiner.FirstNumber - combiner.SecondNumber)
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