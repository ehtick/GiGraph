using System;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="name">
        ///     Specifies the font to use within the scope of the current element.
        /// </param>
        /// <param name="size">
        ///     Specifies the size of the font, in points, to use within the scope of the current element.
        /// </param>
        /// <param name="color">
        ///     Sets the color of the font within the scope of the current element.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendFont(string name, double? size, DotColor color, Action<DotHtmlFont> init)
        {
            return Append(new DotHtmlFont(name, size, color), init);
        }

        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="font">
        ///     The font to use.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendFont(DotFont font, Action<DotHtmlFont> init)
        {
            return Append(new DotHtmlFont(font), init);
        }

        /// <summary>
        ///     Initializes and appends a bold element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendBold(Action<DotHtmlBold> init)
        {
            return Append(new DotHtmlBold(), init);
        }
    }
}