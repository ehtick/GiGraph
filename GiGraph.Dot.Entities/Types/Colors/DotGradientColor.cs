namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a color definition rendered as gradient fill when applied to the root graph, node, or cluster.
    /// </summary>
    public class DotGradientColor : DotMultiColor
    {
        /// <summary>
        ///     Creates a new color definition rendered as gradient fill when applied to the root graph, node, or cluster.
        /// </summary>
        /// <param name="startColor">
        ///     The start color of the gradient fill.
        /// </param>
        /// <param name="endColor">
        ///     The end color of the gradient fill.
        /// </param>
        public DotGradientColor(DotColor startColor, DotColor endColor)
            : base(startColor, endColor)
        {
        }
    }
}