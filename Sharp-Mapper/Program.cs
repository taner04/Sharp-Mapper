using Sharp_Mapper.Interface;
using Sharp_Mapper.Units.Data.Transformer;
using Sharp_Mapper.Units.Data_Transformer;
using Sharp_Mapper.Units.Standard;

var units = new List<IUnit>
{
    new UnitTestMap(),
    new UnitTestMapBack(),
    new UnitTestUpdate(),
    new UnitTestAddStrings(),
    new UnitTestAddNumeric()
};

foreach (var unit in units)
{
    unit.Run();
    Console.WriteLine();
}


