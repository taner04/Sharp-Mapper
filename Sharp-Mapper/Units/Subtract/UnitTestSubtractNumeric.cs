using Sharp_Mapper.Interface.Unit;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Double;
using Sharp_Mapper.Units.Test_Objects.Subtract.Numeric.Int;

namespace Sharp_Mapper.Units.Subtract
{
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
            var combiner = IntSubtract.GetTestObject();

            var mapper = new Mapper<IntSubtractDto, IntSubtract>();
            var mapperResponse = mapper.Map(combiner);

            if (mapperResponse.IsSuccess)
            {
                var combinerDto = mapperResponse.Value;
                if (combinerDto.Result == (combiner.FirstNumber - combiner.SecondNumber))
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

        private void DoubleTest()
        {
            var combiner = DoubleSubtract.GetTestObject();

            var mapper = new Mapper<DoubeSubtractDto , DoubleSubtract>();
            var mapperResponse = mapper.Map(combiner);

            if (mapperResponse.IsSuccess)
            {
                var combinerDto = mapperResponse.Value;
                if (combinerDto.Result == (combiner.FirstNumber - combiner.SecondNumber))
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
