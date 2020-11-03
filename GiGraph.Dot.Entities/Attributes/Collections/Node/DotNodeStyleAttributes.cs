using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeStyleAttributes : DotEntityCommonStyleAttributes<DotNodeStyleOptions>
    {
        protected DotNodeStyleAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotNodeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Rounded" /> style option state.
        /// </summary>
        public virtual bool Rounded
        {
            get => HasOptions(DotStyles.Rounded);
            set => ApplyOption(DotStyles.Rounded, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Diagonals" /> style option state.
        /// </summary>
        public virtual bool Diagonals
        {
            get => HasOptions(DotStyles.Diagonals);
            set => ApplyOption(DotStyles.Diagonals, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Filled" /> style option state.
        /// </summary>
        public virtual bool Filled
        {
            get => HasOptions(DotStyles.Filled);
            set => ApplyOption(DotStyles.Filled, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Striped" /> style option state.
        /// </summary>
        public virtual bool Striped
        {
            get => HasOptions(DotStyles.Striped);
            set => ApplyOption(DotStyles.Striped, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Wedged" /> style option state.
        /// </summary>
        public virtual bool Wedged
        {
            get => HasOptions(DotStyles.Wedged);
            set => ApplyOption(DotStyles.Wedged, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state.
        /// </summary>
        public virtual bool Radial
        {
            get => HasOptions(DotStyles.Radial);
            set => ApplyOption(DotStyles.Radial, value);
        }
    }
}