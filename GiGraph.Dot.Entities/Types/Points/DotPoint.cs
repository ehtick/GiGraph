using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Points
{
    /// <summary>
    ///     Represents a point in an n-dimensional plain.
    /// </summary>
    public class DotPoint : IDotEncodable
    {
        /// <summary>
        ///     Creates and initializes a new point in an n-dimensional plain.
        /// </summary>
        /// <param name="isFixed">
        ///     Indicates whether the node position (if applied to nodes) should not change (input-only).
        /// </param>
        /// <param name="coordinates">
        ///     The coordinates of the point.
        /// </param>
        public DotPoint(bool? isFixed, params double[] coordinates)
        {
            IsFixed = isFixed;
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates), "Coordinate collection cannot be null.");

            if (!coordinates.Any())
            {
                throw new ArgumentException("At least one coordinate has to be specified for a point.", nameof(coordinates));
            }
        }

        /// <summary>
        ///     Creates and initializes a new point in an n-dimensional plain.
        /// </summary>
        /// <param name="coordinates">
        ///     The coordinates of the point.
        /// </param>
        /// <param name="isFixed">
        ///     Indicates whether the node position (if applied to nodes) should not change (input-only).
        /// </param>
        public DotPoint(IEnumerable<double> coordinates, bool? isFixed = null)
            : this(isFixed, coordinates?.ToArray())
        {
        }

        /// <summary>
        ///     Creates and initializes a new point in an n-dimensional plain.
        /// </summary>
        /// <param name="coordinates">
        ///     The coordinates of the point.
        /// </param>
        public DotPoint(params double[] coordinates)
            : this(isFixed: null, coordinates)
        {
        }

        /// <summary>
        ///     Creates and initializes a new single-value point that, depending on the context, may be interpreted as an equal value for
        ///     every component of the attribute the point is assigned to (e.g. padding or margin).
        /// </summary>
        /// <param name="value">
        ///     The value to use.
        /// </param>
        /// <param name="isFixed">
        ///     Indicates whether the node position (if applied to nodes) should not change (input-only).
        /// </param>
        public DotPoint(double value, bool? isFixed = null)
            : this(isFixed, value)
        {
        }

        /// <summary>
        ///     Creates and initializes a new point in a two-dimensional plain.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate of the point.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate of the point.
        /// </param>
        /// <param name="isFixed">
        ///     Indicates whether the node position (if applied to nodes) should not change (input-only).
        /// </param>
        public DotPoint(double x, double y, bool? isFixed = null)
            : this(isFixed, x, y)
        {
        }

        /// <summary>
        ///     Gets the coordinates of the point.
        /// </summary>
        public virtual double[] Coordinates { get; }

        /// <summary>
        ///     Gets or sets the value indicating whether the node position (if applied to nodes) should not change (input-only).
        /// </summary>
        public virtual bool? IsFixed { get; set; }

        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        protected internal virtual string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var fix = true == IsFixed ? "!" : string.Empty;
            return $"{string.Join(",", Coordinates.Select(c => c.ToString(CultureInfo.InvariantCulture)))}{fix}";
        }

        public static implicit operator DotPoint(double? value)
        {
            return value.HasValue ? new DotPoint(value.Value) : null;
        }

        public static implicit operator DotPoint(Point? point)
        {
            return point.HasValue ? new DotPoint(point.Value.X, point.Value.Y) : null;
        }

        public static implicit operator DotPoint(PointF? point)
        {
            return point.HasValue ? new DotPoint(point.Value.X, point.Value.Y) : null;
        }

        public static implicit operator DotPoint(double[] coordinates)
        {
            return coordinates is {} ? new DotPoint(coordinates) : null;
        }

        public static implicit operator DotPoint(int[] coordinates)
        {
            return coordinates is {} ? new DotPoint(coordinates.Select(c => (double) c)) : null;
        }
    }
}