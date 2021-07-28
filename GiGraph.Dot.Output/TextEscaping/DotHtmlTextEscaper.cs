﻿using System.Web;

namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Converts a string to an HTML-encoded string.
    /// </summary>
    public class DotHtmlTextEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value is not null ? HttpUtility.HtmlEncode(value) : value;
        }
    }
}