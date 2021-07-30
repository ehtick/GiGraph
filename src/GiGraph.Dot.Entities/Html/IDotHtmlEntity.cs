using GiGraph.Dot.Output;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML entity.
    /// </summary>
    public interface IDotHtmlEntity : IDotHtmlEncodable
    {
        /// <summary>
        ///     Converts the object to an HTML string. Applies the default (global) HTML syntax and formatting rules.
        /// </summary>
        DotHtmlString ToHtml();
    }
}