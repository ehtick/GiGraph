using System;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends a bold element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendBold(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlBold(), init);
        }

        /// <summary>
        ///     Initializes and appends an italic element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendItalic(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlItalic(), init);
        }

        /// <summary>
        ///     Initializes and appends an underline element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendUnderline(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlUnderline(), init);
        }

        /// <summary>
        ///     Initializes and appends an overline element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendOverline(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlOverline(), init);
        }

        /// <summary>
        ///     Initializes and appends a subscript element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSubscript(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlSubscript(), init);
        }

        /// <summary>
        ///     Initializes and appends a superscript element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSuperscript(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlSuperscript(), init);
        }

        /// <summary>
        ///     Initializes and appends a strikethrough element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStrikethrough(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlStrikethrough(), init);
        }

        /// <summary>
        ///     Initializes and appends nested font style elements.
        /// </summary>
        /// <param name="fontStyle">
        ///     The font style to use.
        /// </param>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStyled(DotFontStyles fontStyle, Action<DotHtmlBuilder> init)
        {
            var rootElement = (IDotHtmlContentEntity) DotHtmlFontStyle.FromStyle(fontStyle, out var contentElement)
             ?? new DotHtmlEntityCollection();

            (contentElement ?? rootElement).SetContent(init);
            return AppendEntity(rootElement);
        }
    }
}