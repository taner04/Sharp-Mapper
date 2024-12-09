using Sharp_Mapper.Interface;
using Sharp_Mapper.Units;

var units = new List<IUnit>
{
    new UnitTestMap(),
    new UnitTestMapBack(),
    new UnitTestUpdate(),
    new UnitTestCombinerString(),
};

foreach (var unit in units)
{
    unit.Run();
}