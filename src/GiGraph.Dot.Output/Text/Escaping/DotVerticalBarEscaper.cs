﻿namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes vertical bars (|). Use for escaping text of record-shaped node fields.
/// </summary>
public class DotVerticalBarEscaper : IDotTextEscaper
{
    string IDotTextEscaper.Escape(string value)
    {
        return Escape(value);
    }

    public static string Escape(string value)
    {
        return value?.Replace("|", "\\|");
    }
}