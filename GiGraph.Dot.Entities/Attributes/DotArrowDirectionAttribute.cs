﻿using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Arrow direction attribute. Assignable to edges only. See the
    ///     <see href="https://www.graphviz.org/doc/info/attrs.html#k:dirType">
    ///         documentation
    ///     </see>
    ///     to view how individual arrow directions are visualized.
    /// </summary>
    public class DotArrowDirectionAttribute : DotAttribute<DotArrowDirection>
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotArrowDirectionAttribute(string key, DotArrowDirection value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value switch
            {
                DotArrowDirection.None => "none",
                DotArrowDirection.Forward => "forward",
                DotArrowDirection.Backward => "back",
                DotArrowDirection.Both => "both",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"The specified arrow direction '{Value}' is not supported.")
            };
        }
    }
}