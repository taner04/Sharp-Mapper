using Sharp_Mapper.Interface.Unit;
using Sharp_Mapper.Units.Combiner;
using Sharp_Mapper.Units.Standard;
using Sharp_Mapper.Units.Subtract;

var units = new List<IUnit>
{
    new UnitTestMap(),
    new UnitTestMapBack(),
    new UnitTestUpdate(),
    new UnitTestCombinerString(),
    new UnitTestCombinerNumber(),
    new UnitTestSubtractNumeric()
};

foreach (var unit in units)
{
    unit.Run();
    Console.WriteLine();
}