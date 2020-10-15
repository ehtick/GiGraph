using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeLabelHyperlinkAttributes : DotEdgeHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeLabelHyperlinkAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeLabelHyperlinkAttributes));

        protected DotEdgeLabelHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeLabelHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeLabelHyperlinkAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     If defined, this is the link used for the label of the edge. This value overrides any hyperlink URL defined for the edge.
        /// </summary>
        [DotAttributeKey("labelURL")]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        [DotAttributeKey("labelhref")]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        /// <summary>
        ///     If <see cref="Url" /> is specified, or if the edge has a hyperlink URL attribute specified, this attribute determines which
        ///     window of the browser is used for the URL attached to the label. Setting it to <see cref="DotHyperlinkTargets.NewWindow" />
        ///     will open a new window if it doesn't already exist, or reuse it if it does. If undefined, the value of the edge's hyperlink
        ///     target is used.
        /// </summary>
        [DotAttributeKey("labeltarget")]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to label of the edge. This is used only if <see cref="Url" /> is specified, or if the edge has a
        ///     hyperlink URL attribute specified.
        /// </summary>
        [DotAttributeKey("labeltooltip")]
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }
    }
}