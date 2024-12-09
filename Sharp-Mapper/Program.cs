using Sharp_Mapper.Interface;
using Sharp_Mapper.Units.Combiner;
using Sharp_Mapper.Units.Standard;

var units = new List<IUnit>
{
    new UnitTestMap(),
    new UnitTestMapBack(),
    new UnitTestUpdate(),
    new UnitTestCombinerString(),
    new UnitTestCombinerNumber()
};

foreach (var unit in units)
{
    unit.Run();
}