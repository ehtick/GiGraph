using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.Font.Attributes;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML &lt;font&gt; element. Supports <see cref="DotHtmlTable" />, text and text styling elements as the content.
    /// </summary>
    public class DotHtmlFont : DotHtmlElement, IDotHtmlFontAttributes
    {
        /// <summary>
        ///     Initializes a new font element instance.
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
        public DotHtmlFont(string name = null, double? size = null, DotColor color = null)
            : this(new DotHtmlFontAttributes())
        {
            if (name is not null)
            {
                Name = name;
            }

            if (size.HasValue)
            {
                Size = size;
            }

            if (color is not null)
            {
                Color = color;
            }
        }

        /// <summary>
        ///     Initializes a new font element instance.
        /// </summary>
        /// <param name="font">
        ///     The font to set.
        /// </param>
        public DotHtmlFont(DotFont font)
            : this(font.Name, font.Size, font.Color)
        {
        }

        /// <summary>
        ///     Initializes a new font element instance.
        /// </summary>
        /// <param name="source">
        ///     The font to set.
        /// </param>
        public DotHtmlFont(IDotHtmlFontAttributes source)
            : this(source.Name, source.Size, source.Color)
        {
        }

        protected DotHtmlFont(DotHtmlFontAttributes attributes)
            : base("font", attributes.Collection)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the font.
        /// </summary>
        public new virtual DotHtmlFontAttributes Attributes { get; }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Name" />
        public virtual string Name
        {
            get => ((IDotHtmlFontAttributes) Attributes).Name;
            set => ((IDotHtmlFontAttributes) Attributes).Name = value;
        }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Size" />
        public virtual double? Size
        {
            get => ((IDotHtmlFontAttributes) Attributes).Size;
            set => ((IDotHtmlFontAttributes) Attributes).Size = value;
        }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Color" />
        public virtual DotColor Color
        {
            get => ((IDotHtmlFontAttributes) Attributes).Color;
            set => ((IDotHtmlFontAttributes) Attributes).Color = value;
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="name">
        ///     Font name.
        /// </param>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        public virtual void Set(string name = null, double? size = null, DotColor color = null)
        {
            Size = size;
            Color = color;
            Name = name;
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotFont attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }

        /// <summary>
        ///     Copies font properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotHtmlFontAttributes attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        public static DotHtmlEntity SetFont(string text, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return SetFont(new DotHtmlText(text), name, size, color, style);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(string text, DotStyledFont font)
        {
            return SetFont(text, font.Name, font.Size, font.Color, font.Style);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        public static DotHtmlEntity SetFont(IEnumerable<(string Text, DotFontStyles Style)> items, string name = null, double? size = null, DotColor color = null)
        {
            return SetFont(DotHtmlFontStyle.SetStyle(items), name, size, color);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(DotStyledFont font, params (string Text, DotFontStyles Style)[] items)
        {
            return SetFont(DotHtmlFontStyle.SetStyle(items), font);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        public static DotHtmlEntityCollection SetFont(params (string Text, DotStyledFont Font)[] items)
        {
            return new DotHtmlEntityCollection(
                items.Select(item => SetFont(item.Text, item.Font))
            );
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
        ///     See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(IDotHtmlEntity entity, DotStyledFont font)
        {
            return SetFont(entity, font.Name, font.Size, font.Color, font.Style);
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
        ///     See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        public static DotHtmlEntity SetFont(IDotHtmlEntity entity, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            var result = style.HasValue
                ? DotHtmlFontStyle.SetStyle(entity, style.Value)
                : entity;

            result = name is not null || color is not null || size.HasValue
                ? new DotHtmlFont
                {
                    Name = name,
                    Size = size,
                    Color = color,
                    Children = { result }
                }
                : result;

            return new DotHtmlEntity<IDotHtmlEntity>(result);
        }
    }
}