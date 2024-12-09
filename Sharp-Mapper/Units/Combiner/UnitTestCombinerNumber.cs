﻿using Sharp_Mapper.Interface.Unit;
using Sharp_Mapper.Mapper;
using Sharp_Mapper.Units.Test_Objects.Combiner.Numeric.Double;
using Sharp_Mapper.Units.Test_Objects.Combiner.Numeric.Int;

namespace Sharp_Mapper.Units.Combiner
{
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
            var combiner = IntCombiner.GetTestObject();

            var mapper = new Mapper<IntCombinerDto, IntCombiner>();
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

        private void DoubleTest()
        {
            var combiner = DoubleCombiner.GetTestObject();

            var mapper = new Mapper<DoubleCombinerDto, DoubleCombiner>();
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
