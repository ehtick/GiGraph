namespace GiGraph.Dot.Types.Geometry
{
    /// <summary>
    ///     Size properties.
    /// </summary>
    /// <param name="Width">
    ///     The width to set.
    /// </param>
    /// <param name="Height">
    ///     The height to set.
    /// </param>
    public record DotSize(double? Width = null, double? Height = null)
    {
        /// <summary>
        ///     The width.
        /// </summary>
        public virtual double? Width { get; init; } = Width;

        /// <summary>
        ///     The height.
        /// </summary>
        public virtual double? Height { get; init; } = Height;
    }
}