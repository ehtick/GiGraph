﻿namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes trailing backslash with the &#92; HTML code.
    /// </summary>
    public class DotTrailingBackslashHtmlEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return true == value?.EndsWith("\\")
                ? $"{value.Remove(value.Length - 1)}&#92;"
                : value;
        }
    }
}