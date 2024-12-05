namespace Sharp_Mapper.Mapper;

[AttributeUsage(AttributeTargets.Property)]
public class NotMappableProperty : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
public class RequieredProperty : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
public class IgnoreProperty : Attribute { }