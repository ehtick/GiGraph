﻿using GiGraph.Dot.Entities.Attributes.Enums;
using System;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An arrow type attribute. Assignable to edges only.
    /// To see how each arrow type is rendered, please go to <seealso cref="https://www.graphviz.org/doc/info/attrs.html#k:arrowType"/>.
    /// </summary>
    public class DotArrowTypeAttribute : DotAttribute<DotArrowType>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotArrowTypeAttribute(string key, DotArrowType value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue()
        {
            switch (Value)
            {
                case DotArrowType.None:
                    return "none";

                case DotArrowType.Normal:
                    return "normal";

                case DotArrowType.Dot:
                    return "dot";

                case DotArrowType.OpenDot:
                    return "odot";

                case DotArrowType.Empty:
                    return "empty";

                case DotArrowType.Diamond:
                    return "diamond";

                case DotArrowType.EmptyDiamond:
                    return "ediamond";

                case DotArrowType.Box:
                    return "box";

                case DotArrowType.Open:
                    return "open";

                case DotArrowType.Vee:
                    return "vee";

                case DotArrowType.Inverted:
                    return "inv";

                case DotArrowType.InvertedDot:
                    return "invdot";

                case DotArrowType.InvertedOpenDot:
                    return "invodot";

                case DotArrowType.Tee:
                    return "tee";

                case DotArrowType.InvertedEmpty:
                    return "invempty";

                case DotArrowType.OpenDiamond:
                    return "odiamond";

                case DotArrowType.Crow:
                    return "crow";

                case DotArrowType.OpenBox:
                    return "obox";

                case DotArrowType.HalfOpen:
                    return "halfopen";

                default:
                    throw new ArgumentOutOfRangeException(nameof(IDotAttribute.GetDotEncodedValue), $"The specified arrow type '{Value}' is not supported.");
            }

        }
    }
}
