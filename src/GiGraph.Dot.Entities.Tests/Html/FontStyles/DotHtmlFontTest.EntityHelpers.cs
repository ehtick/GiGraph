using System.Drawing;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public partial class DotHtmlFontTest
    {
        [Fact]
        public void entity_factory_method_generates_font_with_attributes_and_entity_as_content()
        {
            var font = new DotFont("Arial", 20, Color.Blue);

            var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));

            var entity1 = DotHtmlFont.WithEntity(entityCollection, font);
            var entity2 = DotHtmlFont.WithEntity(entityCollection, font.Name, font.Size, font.Color);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEntity) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_with_attributes_and_entity"
            );
        }

        [Fact]
        public void entity_factory_method_generates_font_without_attributes_with_entity_as_content()
        {
            var font = new DotFont();

            var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));

            var entity1 = DotHtmlFont.WithEntity(entityCollection, font);
            var entity2 = DotHtmlFont.WithEntity(entityCollection, font.Name, font.Size, font.Color);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEntity) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_without_attributes_with_entity"
            );
        }

        [Fact]
        public void entity_factory_method_generates_font_with_attributes_style_tags_and_entity_as_content()
        {
            var font = new DotStyledFont("Arial", 20, Color.Blue, DotFontStyles.Bold | DotFontStyles.Italic);

            var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));

            var entity1 = DotHtmlFont.WithEntity(entityCollection, font);
            var entity2 = DotHtmlFont.WithEntity(entityCollection, font.Name, font.Size, font.Color, font.Style);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEntity) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_styled_font_with_attributes_and_entity"
            );
        }

        [Fact]
        public void entity_factory_method_generates_font_without_attributes_with_style_tags_and_entity_as_content()
        {
            var font = new DotStyledFont(style: DotFontStyles.Bold | DotFontStyles.Italic);

            var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));

            var entity1 = DotHtmlFont.WithEntity(entityCollection, font);
            var entity2 = DotHtmlFont.WithEntity(entityCollection, font.Name, font.Size, font.Color, font.Style);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEntity) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_styled_font_without_attributes_with_entity"
            );
        }
    }
}