using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Enums;

public class DotEnumsTest
{
    public static IEnumerable<object[]> EnumTypes { get; } = GetAllEnumTypes()
       .Select(t => new[] { t })
       .ToArray();

    public static IEnumerable<Type> GetAllEnumTypes()
    {
        var types = Assembly.LoadFrom("GiGraph.Dot.Types.dll")!.GetTypes()
           .Where(t => t.IsEnum)
           .ToArray();

        Assert.NotEmpty(types);
        return types;
    }

    [Theory]
    [MemberData(nameof(EnumTypes))]
    public void all_enums_are_of_int_type(Type enumType)
    {
        // the thing is that some enum mapping methods and those that perform bitwise operations assume that the enums are of type int
        // (otherwise they will throw an exception in runtime)
        Assert.True(Enum.GetUnderlyingType(enumType) == typeof(int));
    }
}