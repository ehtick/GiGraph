﻿namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes backslashes.
/// </summary>
public class DotBackslashEscaper : IDotTextEscaper
{
    string IDotTextEscaper.Escape(string value)
    {
        return Escape(value);
    }

    public static string Escape(string value)
    {
        return value?.Replace("\\", "\\\\");
    }
}