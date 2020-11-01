using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Subgraph
{
    public class DotSubgraphAttributes : DotEntityRootAttributes<IDotSubgraphAttributes>, IDotSubgraphAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup SubgraphAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSubgraphAttributes, IDotSubgraphAttributes>().Build();

        protected DotSubgraphAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotSubgraphAttributes(DotAttributeCollection attributes)
            : this(attributes, SubgraphAttributesKeyLookup)
        {
        }

        public DotSubgraphAttributes()
            : this(new DotAttributeCollection())
        {
        }

        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? Rank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotRank?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankAttribute(k, v.Value));
        }
    }
}