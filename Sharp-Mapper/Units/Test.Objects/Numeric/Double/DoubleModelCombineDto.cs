﻿using Sharp_Mapper.Mapper.Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Numeric.Double;

internal class DoubleModelCombineDto
{
    [MapNumerics("FirstNumber", "SecondNumber")]
    public double Result { get; set; }
}