using System;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
    /// <summary>
    ///     <para>
    ///         Represents a string label. The label can either be a plain text that will be escaped on output DOT script generation, or
    ///         an escaped string (<see cref="DotEscapedString" />) that follows the rules described in the
    ///         <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
    ///             documentation
    ///         </see>
    ///         .
    ///     </para>
    ///     <para>
    ///         When you want to generate an HTML-like label, use <see cref="DotHtmlLabel" /> instead.
    ///     </para>
    /// </summary>
    public class DotLabelString : DotLabel
    {
        protected readonly DotEscapeString _text;

        protected DotLabelString(DotEscapeString text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text), "Text cannot be null.");
        }

        protected DotLabelString(DotEscapedString text)
            : this((DotEscapeString) text)
        {
        }

        protected DotLabelString(string text)
            : this((DotEscapeString) text)
        {
        }

        public override string ToString()
        {
            return _text;
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return _text?.GetDotEncodedString(options, syntaxRules);
        }

        public static implicit operator DotLabelString(string text)
        {
            return text is {} ? new DotLabelString(text) : null;
        }

        public static implicit operator DotLabelString(DotEscapeString text)
        {
            return text is {} ? new DotLabelString(text) : null;
        }

        public static implicit operator string(DotLabelString label)
        {
            return label?._text;
        }

        public static implicit operator DotEscapeString(DotLabelString label)
        {
            return label?._text;
        }
    }
}