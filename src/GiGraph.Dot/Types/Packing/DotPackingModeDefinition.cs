using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     Packing mode definition with two supported options: packing with specified granularity (see
///     <see cref="DotGranularPackingMode" />) or array packing (see <see cref="DotArrayPackingMode" />).
/// </summary>
public abstract record DotPackingModeDefinition : IDotEncodable
{
    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return GetDotEncodedValue(options, syntaxRules);
    }

    public static implicit operator DotPackingModeDefinition(DotPackingGranularity? value)
    {
        return value.HasValue ? new DotGranularPackingMode(value.Value) : null;
    }

    public static implicit operator DotPackingModeDefinition(DotArrayPackingOptions? value)
    {
        return value.HasValue ? new DotArrayPackingMode(value.Value) : null;
    }

    public static implicit operator DotPackingModeDefinition(int? value)
    {
        return value.HasValue ? new DotArrayPackingMode(value.Value) : null;
    }

    protected abstract string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
}